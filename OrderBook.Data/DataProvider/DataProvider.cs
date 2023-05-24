using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderBook.Data.Enums;
using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderBook.Data.DataProvider;

public class DataProvider : IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }
    private readonly string _jsonTickersPath;
    private readonly string _jsonOrderBooksPath;

    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly IConfiguration _configuration;

    public DataProvider(IConfiguration configuration)
    {
        _configuration = configuration;

        _jsonOrderBooksPath = _configuration.GetSection("AppSettings:JsonOrderBooksPath").Value ?? string.Empty;
        _jsonTickersPath = _configuration.GetSection("AppSettings:JsonTickersPath").Value ?? string.Empty;
        
        if (string.IsNullOrEmpty(_jsonOrderBooksPath) || string.IsNullOrEmpty(_jsonTickersPath))
            Console.WriteLine("JSON file not found in appsettings.");

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        OrderBooks = new List<OrderBookModel>();
        Tickers = new List<TickerModel>();

        LoadData();
    }

    public void LoadData()
    {
        LoadOrderBooksData();
        LoadTickersData();
    }
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

    public async Task<OrderBookModel?> GetOrderBookByTicker(string tickerSymbol)
    {
        LoadTickersData();
        return await Task.FromResult(OrderBooks.FirstOrDefault(e => e.Ticker.Symbol == tickerSymbol));
    }


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
