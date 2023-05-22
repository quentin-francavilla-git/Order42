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

    public OrderBookApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
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

        return orderBooks;
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
