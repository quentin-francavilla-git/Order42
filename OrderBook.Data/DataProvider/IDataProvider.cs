using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.Data.DataProvider;

public interface IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }

    public Task<OrderBookModel?> GetOrderBookByTicker(string tickerSymbol);

    public Task<int> EntryOrder(OrderModel order, string symbol, string entryType);
}
