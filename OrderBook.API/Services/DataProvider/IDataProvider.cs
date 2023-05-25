using OrderBook.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderBook.API.Services.DataProvider;

public interface IDataProvider
{
    public List<OrderBookModel> OrderBooks { get; set; }
    public List<TickerModel> Tickers { get; set; }
    public List<TradeModel> Trades { get; set; }

    public void LoadData();

    // Trade
    public void WriteAndGenerateTrades();
    public void ApplyTrades();

    // OrderBook
    public Task<OrderBookModel?> GetOrderBookByTicker(string tickerSymbol);

    // Order
    public Task<int> EntryOrder(OrderModel order, string symbol, string entryType);
}
