using OrderBook.Data.Models;
using OrderBook.UI.Helpers.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OrderBook.Data.Services;

public interface IOrderBookApiService
{
    public event EventHandler DataUpdated;
    public Task<ObservableCollection<OrderBookModel>?> GetOrderBook();
    public Task<ObservableCollection<TickerModel>?> GetTicker();
    public Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol);
    public Task<int> EntryOrder(OrderModel order, string symbol, string entryType);
}
