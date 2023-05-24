using OrderBook.Data.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OrderBook.API.Services.ApiBridge;

public interface IApiBridge
{
    public event EventHandler DataUpdated;
    public Task<ObservableCollection<OrderBookModel>?> GetOrderBook();
    public Task<ObservableCollection<TickerModel>?> GetTicker();
    public Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol);
    public Task<int> EntryOrder(OrderModel order, string symbol, string entryType);
}
