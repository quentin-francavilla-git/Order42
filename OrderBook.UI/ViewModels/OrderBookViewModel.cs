using OrderBook.Data.Models;
using OrderBook.Data.Services;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class OrderBookViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;
    private List<OrderModel> _bids;
    private List<OrderModel> _asks;
    public OrderBookModel OrderBook { get; set; }
    private List<(XEntryForm Form, EntryViewModel ViewModel)> formViewModelPairs = new List<(XEntryForm, EntryViewModel)>();


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

    // Other methods
    //public async void RefreshData(object? sender, EventArgs e)
    //{
    //    var updatedOrderBooks = await LoadOrderBooks();

    //    if (updatedOrderBooks != null)
    //    {
    //        await LoadOrderBookByTicker(OrderBook.Ticker.Symbol);
    //    }
    //}

    public async Task<ObservableCollection<OrderBookModel>?> LoadOrderBooks()
    {
       return await _orderBookApiService.GetOrderBook();
    }

    public async Task<ObservableCollection<TickerModel>> LoadTickers()
    {
        return await _orderBookApiService.GetTicker();
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

    public void OpenEntryForm()
    {
        var entryViewModel = new EntryViewModel(_orderBookApiService);

        var entryForm = new XEntryForm(entryViewModel, this, Ticker.Symbol);

        formViewModelPairs.Add((entryForm, entryViewModel));

        entryForm.FormClosed += (sender, e) =>
        {
            var closedForm = sender as XEntryForm;
            if (closedForm != null)
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
