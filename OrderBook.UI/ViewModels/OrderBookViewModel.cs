using DevExpress.Data.Browsing;
using OrderBook.Data;
using OrderBook.Data.Models;

namespace OrderBook.UI.ViewModels;

public class OrderBookViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;
    private List<OrderModel> _bids;
    private List<OrderModel> _asks;
    public OrderBookModel OrderBook { get; set; }

    public OrderBookViewModel(OrderBookModel orderBook, IOrderBookApiService orderBookApiService)
    {
        OrderBook = orderBook;
        _orderBookApiService = orderBookApiService;
        _bids = new List<OrderModel>();
        _asks = new List<OrderModel>();
    }

    public TickerModel Ticker
    {
        get => OrderBook.Ticker;
        set
        {
            if (OrderBook.Ticker != value)
            {
                OrderBook.Ticker = value;
                RaisePropertyChanged();
            }
        }
    }

    public List<OrderModel> Bids
    {
        get => _bids;
        set
        {
            if (!Enumerable.SequenceEqual(_bids, value))
            {
                _bids = value;
                RaisePropertyChanged();
            }
        }
    }

    public List<OrderModel> Asks
    {
        get => _asks;
        set
        {
            if (!Enumerable.SequenceEqual(_asks, value))
            {
                _asks = value;
                RaisePropertyChanged();
            }
        }
    }

    public async Task LoadOrderBookByTicker(string tickerSymbol)
    {
        var orderBook = await _orderBookApiService.GetOrderBookByTicker(tickerSymbol);
        if (orderBook != null)
        {
            // Update the order book properties with the retrieved data
            Ticker = orderBook.Ticker;
            Bids = new List<OrderModel>(orderBook.Bids); // Create a new list to trigger property change
            Asks = new List<OrderModel>(orderBook.Asks); // Create a new list to trigger property change
        }
    }
}
