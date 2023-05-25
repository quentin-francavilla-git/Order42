using Newtonsoft.Json;
using OrderBook.Data.Models;
using OrderBook.UI.Helpers.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.API.Services.ApiBridge;

public class ApiBridge : IApiBridge
{
    public event EventHandler DataUpdated = delegate { };
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7228";

    public ApiBridge()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl)
        };
    }

    // ----- Post (Commands)
    public async Task<int> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        try
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
        catch (HttpRequestException ex)
        {
            ErrorHandlerService.RaiseError("Failed to connect to the API: " + ex.Message);
            return 42;
        }
    }

    // ----- GET (Queries)

    public async Task<ObservableCollection<OrderBookModel>?> GetOrderBook()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/orderbook");
            response.EnsureSuccessStatusCode();

            var orderBooks = await response.Content.ReadFromJsonAsync<ObservableCollection<OrderBookModel>>();
            return orderBooks;
        }
        catch (HttpRequestException ex)
        {
            ErrorHandlerService.RaiseError("Failed to connect to the API: " + ex.Message);
            return null;
        }
    }

    public async Task<ObservableCollection<TickerModel>?> GetTicker()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/ticker");
            response.EnsureSuccessStatusCode();

            var tickers = await response.Content.ReadFromJsonAsync<ObservableCollection<TickerModel>>() ?? new ObservableCollection<TickerModel>();

            return tickers;
        }
        catch (HttpRequestException ex)
        {
            ErrorHandlerService.RaiseError("Failed to connect to the API: " + ex.Message);
            return null;
        }
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
        catch (JsonException ex)
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

    public async Task<List<TradeModel>?> GetTrades()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/trade");
            response.EnsureSuccessStatusCode();

            var trades = await response.Content.ReadFromJsonAsync<List<TradeModel>>() ?? new List<TradeModel>();

            return trades;
        }
        catch (HttpRequestException ex)
        {
            ErrorHandlerService.RaiseError("Failed to connect to the API: " + ex.Message);
            return null;
        }
    }
}
