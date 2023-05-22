using Newtonsoft.Json;
using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Data.Services;

public class OrderBookApiService : IOrderBookApiService
{
    public event EventHandler DataUpdated = delegate { };
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7228";
    private ObservableCollection<OrderBookModel>? _lastOrderBooks;

    public OrderBookApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<ObservableCollection<OrderBookModel>?> GetInitialOrderBooks()
    {
        var response = await _httpClient.GetAsync("api/orderbook");
        response.EnsureSuccessStatusCode();

        var orderBooks = await response.Content.ReadFromJsonAsync<ObservableCollection<OrderBookModel>>();

        _lastOrderBooks = orderBooks;

        return orderBooks;
    }

    // ----- Post (Commands)
    public async Task<int> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        // Convert the order to JSON
        var jsonOrder = JsonConvert.SerializeObject(order);
        var content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
        var url = $"api/order/entryOrder?symbol={symbol}&entryType={entryType}";

        // Send the HTTP POST request to the controller endpoint
        var response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        int resultCode = 0;

        if (response.IsSuccessStatusCode)
        {
            var resultContent = await response.Content.ReadAsStringAsync();
            resultCode = int.Parse(resultContent);
        }

        // Raise event -> OrderbookViewModel RefreshData()
        DataUpdated?.Invoke(null, EventArgs.Empty);

        return resultCode;
    }

    // ----- GET (Queries)

    public async Task<ObservableCollection<OrderBookModel>?> GetOrderBook()
    {
        var response = await _httpClient.GetAsync("api/orderbook");
        response.EnsureSuccessStatusCode();

        var orderBooks = await response.Content.ReadFromJsonAsync<ObservableCollection<OrderBookModel>>();
        if (orderBooks != null && !AreOrderBooksEqual(orderBooks, _lastOrderBooks))
        {
            _lastOrderBooks = orderBooks;
            return orderBooks;
        }

        return null;
    }

    private bool AreOrderBooksEqual(ObservableCollection<OrderBookModel>? orderBooks1, ObservableCollection<OrderBookModel>? orderBooks2)
    {
        if (orderBooks1 == null && orderBooks2 == null)
            return true;

        if (orderBooks1 == null || orderBooks2 == null)
            return false;

        for (int i = 0; i < orderBooks1.Count; i++)
        {
            var orderBook1 = orderBooks1[i];
            var orderBook2 = orderBooks2[i];

            // Compare the Ticker
            if (!AreTickersEqual(orderBook1.Ticker, orderBook2.Ticker))
                return false;

            // Compare the Bids
            if (!AreOrdersEqual(orderBook1.Bids, orderBook2.Bids))
                return false;

            // Compare the Asks
            if (!AreOrdersEqual(orderBook1.Asks, orderBook2.Asks))
                return false;
        }

        return true;
    }

    private bool AreTickersEqual(TickerModel ticker1, TickerModel ticker2)
    {
        // Compare the properties of TickerModel for equality
        return ticker1.Symbol == ticker2.Symbol; // Add other relevant property comparisons if needed
    }

    private bool AreOrdersEqual(List<OrderModel> orders1, List<OrderModel> orders2)
    {
        if (orders1.Count != orders2.Count)
            return false;

        for (int i = 0; i < orders1.Count; i++)
        {
            var order1 = orders1[i];
            var order2 = orders2[i];

            // Compare the properties of OrderModel for equality
            if (order1.Type != order2.Type || order1.Price != order2.Price || order1.Quantity != order2.Quantity || order1.Total != order2.Total || order1.ProductType != order2.ProductType)
                return false;
        }

        return true;
    }

    public async Task<ObservableCollection<TickerModel>> GetTicker()
    {
        var response = await _httpClient.GetAsync("api/ticker");
        response.EnsureSuccessStatusCode();

        var tickers = await response.Content.ReadFromJsonAsync<ObservableCollection<TickerModel>>() ?? new ObservableCollection<TickerModel>();

        return tickers;
    }
    public async Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/orderbook/byTicker/{tickerSymbol}");
            response.EnsureSuccessStatusCode();

            var orderBook = await response.Content.ReadFromJsonAsync<OrderBookModel>() ?? new OrderBookModel();
            return orderBook;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("An error occurred while making the HTTP request: " + ex.Message);
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine("An error occurred while parsing the JSON response: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }

        return new OrderBookModel
        {
            Ticker = new TickerModel
            {
                Symbol = "No Data"
            },
            Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 0,
                        Quantity = 0,
                    }
                },
            Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 0,
                        Quantity = 0,
                    }
                },
        };
    }

}
