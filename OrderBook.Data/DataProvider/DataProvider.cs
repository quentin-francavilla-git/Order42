using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Data.DataProvider;

public class DataProvider : IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }
    // Add more properties as needed

    public DataProvider()
    {
        LoadOrderBooksData();
        LoadTickersData();
    }

    public async Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol)
    {
        return await Task.FromResult(OrderBooks.FirstOrDefault(e => e.Ticker.Symbol == tickerSymbol));
    }

    private void LoadTickersData()
    {
        Tickers = new List<TickerModel>
        {
            new TickerModel
            {
                Symbol = "GOOGL"
            },
            new TickerModel
            {
                Symbol = "AAPL"
            },
            new TickerModel
            {
                Symbol = "AMZN"
            },
            new TickerModel
            {
                Symbol = "MSFT"
            },
        };
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
                    Symbol = "GOOGL"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 5500,
                        Quantity = 1,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5300,
                        Quantity = 65,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 4200,
                        Quantity = 14,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 3940,
                        Quantity = 991,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 3440,
                        Quantity = 3333,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3100,
                        Quantity = 8967,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 2980,
                        Quantity = 991,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 2900,
                        Quantity = 12,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 2387,
                        Quantity = 198,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 1943,
                        Quantity = 687,
                        ProductType = "Options"
                    },
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6121,
                        Quantity = 5346,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5820,
                        Quantity = 9275,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 5521,
                        Quantity = 6748,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5222,
                        Quantity = 1204,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4876,
                        Quantity = 6527,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4647,
                        Quantity = 4197,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4345,
                        Quantity = 2672,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3947,
                        Quantity = 8487,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 3662,
                        Quantity = 2753,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3352,
                        Quantity = 7957,
                        ProductType = "Options"
                    }
                },
            },
            new OrderBookModel
            {
                Ticker = new TickerModel
                {
                    Symbol = "AAPL"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6195,
                        Quantity = 7819,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5866,
                        Quantity = 3840,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5544,
                        Quantity = 9836,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5269,
                        Quantity = 1456,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 4977,
                        Quantity = 6357,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4723,
                        Quantity = 5550,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4402,
                        Quantity = 2874,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4077,
                        Quantity = 9276,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3843,
                        Quantity = 3771,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3521,
                        Quantity = 6955,
                        ProductType = "Futures"
                    }
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6632,
                        Quantity = 2345,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 6305,
                        Quantity = 4035,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5998,
                        Quantity = 9801,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5672,
                        Quantity = 543,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 5379,
                        Quantity = 7027,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5075,
                        Quantity = 2512,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4752,
                        Quantity = 1597,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4453,
                        Quantity = 6818,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4176,
                        Quantity = 1987,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 3834,
                        Quantity = 4766,
                        ProductType = "Equities"
                    }
                },
            },
            new OrderBookModel
            {
                Ticker = new TickerModel
                {
                    Symbol = "AMZN"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6723,
                        Quantity = 3176,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 6361,
                        Quantity = 4589,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 6062,
                        Quantity = 1843,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5719,
                        Quantity = 7852,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5432,
                        Quantity = 2359,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5150,
                        Quantity = 6452,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4843,
                        Quantity = 3721,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4535,
                        Quantity = 2790,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 4206,
                        Quantity = 9165,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 3932,
                        Quantity = 5481,
                        ProductType = "Options"
                    }
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6687,
                        Quantity = 872,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 6332,
                        Quantity = 5061,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 6031,
                        Quantity = 1833,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 5735,
                        Quantity = 7091,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5477,
                        Quantity = 2254,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5201,
                        Quantity = 3655,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4883,
                        Quantity = 2847,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4592,
                        Quantity = 9615,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4261,
                        Quantity = 1563,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 3976,
                        Quantity = 4452,
                        ProductType = "Bonds"
                    }
                },
            },
            new OrderBookModel
            {
                Ticker = new TickerModel
                {
                    Symbol = "MSFT"
                },
                Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6798,
                        Quantity = 2165,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 6442,
                        Quantity = 3689,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 6119,
                        Quantity = 9132,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5812,
                        Quantity = 481,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5549,
                        Quantity = 6218,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5245,
                        Quantity = 2521,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4918,
                        Quantity = 1518,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4589,
                        Quantity = 7857,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 4291,
                        Quantity = 2053,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 3974,
                        Quantity = 4201,
                        ProductType = "Equities"
                    }
                },
                Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 6992,
                        Quantity = 2487,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 6621,
                        Quantity = 4132,
                        ProductType = "Futures"
                    },
                    new OrderModel
                    {
                        Price = 6309,
                        Quantity = 1911,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 5986,
                        Quantity = 5598,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5674,
                        Quantity = 2564,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 5345,
                        Quantity = 3221,
                        ProductType = "Equities"
                    },
                    new OrderModel
                    {
                        Price = 5011,
                        Quantity = 1797,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4715,
                        Quantity = 7452,
                        ProductType = "Options"
                    },
                    new OrderModel
                    {
                        Price = 4378,
                        Quantity = 2936,
                        ProductType = "Bonds"
                    },
                    new OrderModel
                    {
                        Price = 4057,
                        Quantity = 4921,
                        ProductType = "Futures"
                    }
                },
            },
        };
    }
}
