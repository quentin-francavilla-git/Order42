using OrderBook.Data.Models;
using OrderBook.Data.Services;
using OrderBook.UI.Helpers.ErrorHandler;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class OrderBookViewModel : ViewModelBase
{
    private readonly IApiManager _apiManager;

    private List<OrderModel> _bids;
    private List<OrderModel> _asks;
    public OrderBookModel OrderBook { get; set; }
    private readonly List<(XEntryForm Form, EntryViewModel ViewModel)> formViewModelPairs = new();


    public OrderBookViewModel(OrderBookModel orderBook, IApiManager apiManager)
    {
        OrderBook = orderBook;
        _apiManager = apiManager;

        _bids = new List<OrderModel>();
        _asks = new List<OrderModel>();

        _apiManager.DataUpdated += RefreshData;
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

    // Other methods
    public async void RefreshData(object? sender, EventArgs e)
    {
        var updatedOrderBooks = await LoadOrderBooks();

        if (updatedOrderBooks != null)
        {
            await LoadOrderBookByTicker(OrderBook.Ticker.Symbol);
        }
    }

    public async Task<ObservableCollection<OrderBookModel>?> LoadOrderBooks()
    {
       return await _apiManager.GetOrderBook();
    }

    public async Task<ObservableCollection<TickerModel>?> LoadTickers()
    {
        return await _apiManager.GetTicker();
    }

    public async Task LoadOrderBookByTicker(string tickerSymbol)
    {
        var orderBook = await _apiManager.GetOrderBookByTicker(tickerSymbol);
        if (orderBook != null)
        {
            // Update the order book properties with the retrieved data
            Ticker = orderBook.Ticker;
            Bids = new List<OrderModel>(orderBook.Bids); // Create a new list to trigger property change
            Asks = new List<OrderModel>(orderBook.Asks); // Create a new list to trigger property change
        }
    }

    public void OpenEntryForm()
    {
        var entryViewModel = new EntryViewModel(_apiManager);

        var entryForm = new XEntryForm(entryViewModel, Ticker.Symbol);

        formViewModelPairs.Add((entryForm, entryViewModel));

        entryForm.FormClosed += (sender, e) =>
        {
            if (sender is XEntryForm closedForm)
            {
                var pair = formViewModelPairs.FirstOrDefault(x => x.Form == closedForm);
                if (pair != default)
                {
                    formViewModelPairs.Remove(pair);
                }
            }
        };

        entryForm.Show();
    }
}
