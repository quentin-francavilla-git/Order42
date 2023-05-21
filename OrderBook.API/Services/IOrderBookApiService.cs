using OrderBook.Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OrderBook.Data.Services;

public interface IOrderBookApiService
{
    public Task<ObservableCollection<OrderBookModel>?> GetOrderBook();
    public Task<ObservableCollection<TickerModel>> GetTicker();
    public Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol);
    public Task<int> PlaceOrder(OrderModel order, string symbol);
    public Task<int> AmendOrder(OrderModel order, string symbol);
}
