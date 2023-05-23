using OrderBook.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderBook.Data.DataProvider;

public interface IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }

    public void LoadData();

    public Task<OrderBookModel?> GetOrderBookByTicker(string tickerSymbol);

    public Task<int> EntryOrder(OrderModel order, string symbol, string entryType);
}
