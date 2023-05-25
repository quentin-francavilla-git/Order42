using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderBook.Data.Enums;
using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderBook.API.Services.DataProvider;

public class DataProvider : IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }
    public List<TradeModel> Trades { get; set; }

    public List<TradeModel> NewTrades { get; set; }

    private readonly string _jsonTickersPath;
    private readonly string _jsonOrderBooksPath;
    private readonly string _jsonTradesPath;

    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly IConfiguration _configuration;

    private readonly Random _random = new();

    public DataProvider(IConfiguration configuration)
    {
        _configuration = configuration;

        _jsonOrderBooksPath = _configuration.GetSection("AppSettings:JsonOrderBooksPath").Value ?? string.Empty;
        _jsonTickersPath = _configuration.GetSection("AppSettings:JsonTickersPath").Value ?? string.Empty;
        _jsonTradesPath = _configuration.GetSection("AppSettings:JsonTradesPath").Value ?? string.Empty;

        if (string.IsNullOrEmpty(_jsonOrderBooksPath) || string.IsNullOrEmpty(_jsonTickersPath) || string.IsNullOrEmpty(_jsonTradesPath))
            Console.WriteLine("JSON file not found in appsettings.");

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        OrderBooks = new List<OrderBookModel>();
        Tickers = new List<TickerModel>();
        Trades = new List<TradeModel>();
        NewTrades = new List<TradeModel>();

        LoadData();
    }

    public void LoadData()
    {
        LoadOrderBooksData();
        LoadTickersData();
        LoadTradesData();
    }

    // Load Data
    private void LoadTickersData()
    {
        try
        {
            string jsonData = File.ReadAllText(_jsonTickersPath);

            Tickers = JsonConvert.DeserializeObject<List<TickerModel>>(jsonData) ?? new List<TickerModel>();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("JSON file not found: " + ex.Message);
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine("Error in JSON deserialization: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private void LoadOrderBooksData()
    {
        try
        {
            string jsonData = File.ReadAllText(_jsonOrderBooksPath);

            OrderBooks = JsonConvert.DeserializeObject<List<OrderBookModel>>(jsonData) ?? new List<OrderBookModel>();

            foreach (var orderBook in OrderBooks)
            {
                foreach (var bid in orderBook.Bids)
                {
                    bid.Total = bid.Price * bid.Quantity;
                }

                foreach (var ask in orderBook.Asks)
                {
                    ask.Total = ask.Price * ask.Quantity;
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("JSON file not found: " + ex.Message);
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine("Error in JSON deserialization: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private void LoadTradesData()
    {
        try
        {
            string jsonData = File.ReadAllText(_jsonTradesPath);

            Trades = JsonConvert.DeserializeObject<List<TradeModel>>(jsonData) ?? new List<TradeModel>();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("JSON file not found: " + ex.Message);
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine("Error in JSON deserialization: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    // Trade
    public void WriteAndGenerateTrades()
    {
        NewTrades.Clear();
        NewTrades = GenerateTrades();

        var existingTrades = new List<TradeModel>();

        if (File.Exists(_jsonTradesPath))
        {
            var existingJson = File.ReadAllText(_jsonTradesPath);
            existingTrades = JsonConvert.DeserializeObject<List<TradeModel>>(existingJson) ?? new List<TradeModel>();
        }

        existingTrades.AddRange(NewTrades);

        var sortedTrades = existingTrades.OrderByDescending(t => t.Time).ToList();

        var updatedJson = System.Text.Json.JsonSerializer.Serialize(sortedTrades, _jsonSerializerOptions);

        // Write updated
        File.WriteAllText(_jsonTradesPath, updatedJson);

        LoadData();
    }

    private List<TradeModel> GenerateTrades()
    {
        var trades = new List<TradeModel>();
        var orderBooks = OrderBooks; // get your list of OrderBooks

        foreach (var orderBook in orderBooks)
        {
            var order = GetRandomOrder(orderBook);
            if (order != null)
            {
                string side = order.Type == nameof(EnumAction.Bid) ? side = "BUY" : side = "SELL";

                var trade = new TradeModel
                {
                    Time = order.Time,
                    Side = side,
                    Ticker = orderBook.Ticker.Symbol,
                    Quantity = _random.Next(1, order.Quantity + 1),
                    Price = order.Price,
                    ProductType = order.ProductType
                };
                trades.Add(trade);
            }
        }

        Console.WriteLine("Trades Generated.");

        return trades.OrderByDescending(t => t.Time).ToList(); ;
    }
    private OrderModel? GetRandomOrder(OrderBookModel orderBook)
    {
        var allOrders = new List<OrderModel>();
        allOrders.AddRange(orderBook.Bids);
        allOrders.AddRange(orderBook.Asks);

        if (allOrders.Any())
        {
            return allOrders[_random.Next(allOrders.Count)];
        }
        else
        {
            return null;
        }
    }

    public void ApplyTrades()
    {
        foreach (var trade in NewTrades)
        {
            foreach (var orderBook in OrderBooks)
            {
                orderBook.Bids = ApplyTradeToOrders(trade, orderBook.Bids);
                orderBook.Asks = ApplyTradeToOrders(trade, orderBook.Asks);
            }
        }

        // apply changed in the files
        var updatedOrderBooksJson = System.Text.Json.JsonSerializer.Serialize(OrderBooks, _jsonSerializerOptions);
        File.WriteAllText(_jsonOrderBooksPath, updatedOrderBooksJson);
    }

    private List<OrderModel> ApplyTradeToOrders(TradeModel trade, List<OrderModel> orders)
    {
        for (int i = orders.Count - 1; i >= 0; i--)
        {
            if (orders[i].Price == trade.Price)
            {
                orders[i].Quantity -= trade.Quantity;
                if (orders[i].Quantity <= 0)
                {
                    orders.RemoveAt(i);
                }
            }
        }
        return orders;
    }

    // OrderBook
    public async Task<OrderBookModel?> GetOrderBookByTicker(string tickerSymbol)
    {
        LoadTickersData();
        return await Task.FromResult(OrderBooks.FirstOrDefault(e => e.Ticker.Symbol == tickerSymbol));
    }
    
    // Order
    public async Task<int> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        int resultCode = 0;
        // Read the existing JSON data from the file
        var jsonData = File.ReadAllText(_jsonOrderBooksPath);

        // Deserialize the JSON data into a list of OrderBookModel objects
        var orderBooks = System.Text.Json.JsonSerializer.Deserialize<List<OrderBookModel>>(jsonData, _jsonSerializerOptions);

        if (orderBooks == null)
        {
            Console.WriteLine("Order Books list cannot be null.");
            return 42;
        }

        // Find the OrderBookModel with the specified Ticker.Symbol
        var orderBook = await Task.FromResult(orderBooks.FirstOrDefault(ob => ob.Ticker.Symbol == symbol) ?? new OrderBookModel());

        if (orderBook != null)
        {
            if (order.Type == nameof(EnumAction.Bid))
            {
                // Find the matching order in the bids and asks lists
                var existingBid = orderBook.Bids.FirstOrDefault(o => o.Price == order.Price && o.ProductType == order.ProductType);
                if (existingBid != null)
                {
                    // Remove existing bid
                    if (entryType == nameof(EnumEntryType.CancelOrder))
                        orderBook.Bids.RemoveAll(o => o.Price == order.Price && o.ProductType == order.ProductType);
                    else
                    {
                        // Update the existing bid order quantity
                        existingBid.Quantity = order.Quantity;
                        existingBid.Time = order.Time;
                    }
                    resultCode = 1;
                }
                else
                {
                    if (entryType == nameof(EnumEntryType.PlaceOrder))
                        orderBook.Bids.Add(order);
                    resultCode = 2;
                }
            }
            // Same logic for the asks
            else if (order.Type == nameof(EnumAction.Ask))
            {
                var existingAsk = orderBook.Asks.FirstOrDefault(o => o.Price == order.Price && o.ProductType == order.ProductType);

                if (existingAsk != null)
                {
                    if (entryType == nameof(EnumEntryType.CancelOrder))
                        orderBook.Asks.RemoveAll(o => o.Price == order.Price && o.ProductType == order.ProductType);
                    else
                    {
                        // Update the existing bid order quantity
                        existingAsk.Quantity = order.Quantity;
                        existingAsk.Time = order.Time;
                    }
                    resultCode = 1;
                }
                else
                {
                    if (entryType == nameof(EnumEntryType.PlaceOrder))
                        orderBook.Asks.Add(order);

                    resultCode = 2;
                }
            }
        }

        // Sorting by price
        orderBooks.ForEach(ob =>
        {
            ob.Bids.Sort((o1, o2) => o2.Price.CompareTo(o1.Price));
            ob.Asks.Sort((o1, o2) => o2.Price.CompareTo(o1.Price));
        });

        // Serialize the updated list of order books back to JSON
        var updatedJsonData = System.Text.Json.JsonSerializer.Serialize(orderBooks, _jsonSerializerOptions);

        // Write the updated JSON data back to the file
        File.WriteAllText(_jsonOrderBooksPath, updatedJsonData);
        return resultCode;
    }
}
