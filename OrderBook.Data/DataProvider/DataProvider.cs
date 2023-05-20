using Newtonsoft.Json;
using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace OrderBook.Data.DataProvider;

public class DataProvider : IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }
    private readonly string _jsonTickersPath;
    private readonly string _jsonOrderBooksPath;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public DataProvider()
    {
        _jsonTickersPath = "C:\\Users\\Quentin\\Documents\\Projets\\.NET\\WinForms\\MiraeOrderBook\\OrderBook.Data\\JsonData\\tickers.json";
        _jsonOrderBooksPath = "C:\\Users\\Quentin\\Documents\\Projets\\.NET\\WinForms\\MiraeOrderBook\\OrderBook.Data\\JsonData\\orderbooks.json";
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
        LoadOrderBooksData();
        LoadTickersData();
    }

    public async Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol)
    {
        LoadTickersData();
        return await Task.FromResult(OrderBooks.FirstOrDefault(e => e.Ticker.Symbol == tickerSymbol));
    }

    private void LoadTickersData()
    {
        try
        {
            string jsonData = File.ReadAllText(_jsonTickersPath);

            Tickers = JsonConvert.DeserializeObject<List<TickerModel>>(jsonData);
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

            OrderBooks = JsonConvert.DeserializeObject<List<OrderBookModel>>(jsonData);

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

    public async Task PlaceOrder(OrderModel order, string symbol)
    {
        // Read the existing JSON data from the file
        var jsonData = File.ReadAllText(_jsonOrderBooksPath);

        // Deserialize the JSON data into a list of OrderBookModel objects
        var orderBooks = System.Text.Json.JsonSerializer.Deserialize<List<OrderBookModel>>(jsonData, _jsonSerializerOptions);

        // Find the OrderBookModel with the specified Ticker.Symbol
        var orderBook = await Task.FromResult(orderBooks.FirstOrDefault(ob => ob.Ticker.Symbol == symbol));

        if (orderBook != null)
        {
            if (order.Type == "Bid")
            {
                // Find the matching order in the bids and asks lists
                var existingBid = orderBook.Bids.FirstOrDefault(o => o.Price == order.Price);
                if (existingBid != null)
                {
                    // Update the existing bid order quantity
                    existingBid.Quantity = order.Quantity;
                }
            }
            else if (order.Type == "Ask")
            {
                var existingAsk = orderBook.Asks.FirstOrDefault(o => o.Price == order.Price);

                if (existingAsk != null)
                {
                    // Update the existing ask order quantity
                    existingAsk.Quantity = order.Quantity;
                }
            }
        }

        // Serialize the updated list of order books back to JSON
        var updatedJsonData = System.Text.Json.JsonSerializer.Serialize(orderBooks, _jsonSerializerOptions);

        // Write the updated JSON data back to the file
        File.WriteAllText(_jsonOrderBooksPath, updatedJsonData);
    }
}
