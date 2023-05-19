using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Data;

public class DataProvider : IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    // Add more properties as needed

    public DataProvider()
    {
        LoadOrderBooksData();
    }

    public async Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol)
    {
        return await Task.FromResult(OrderBooks.FirstOrDefault(e => e.Ticker.Symbol == tickerSymbol));
    }

    private void LoadOrderBooksData()
    {
        // Initialize the shared data
        OrderBooks = new List<OrderBookModel>
        {
            new OrderBookModel
            {
                Ticker = new TickerModel
                {
                    Symbol = "GOOGL",
                    ProductType = "Futures"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 5500,
                        Quantity = 1,
                    },
                    new OrderModel
                    {
                        Price = 5300,
                        Quantity = 65,
                    },
                    new OrderModel
                    {
                        Price = 4200,
                        Quantity = 14,
                    },
                    new OrderModel
                    {
                        Price = 3940,
                        Quantity = 991,
                    },
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 666,
                        Quantity = 9,
                    }
                },
            },
            new OrderBookModel
            {
                Ticker = new TickerModel
                {
                    Symbol = "APPL",
                    ProductType = "Options"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 232323,
                        Quantity = 66,
                    }
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 1111,
                        Quantity = 190,
                    }
                },
            },
        };
    }
}
