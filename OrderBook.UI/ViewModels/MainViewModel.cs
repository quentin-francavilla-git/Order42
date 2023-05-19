using OrderBook.Data.DataProvider;
using OrderBook.Data.Models;
using OrderBook.Data.Services;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;
    private readonly IDataProvider _dataProvider;
    public ObservableCollection<OrderBookViewModel> OrderBooks { get; } = new();
    public ObservableCollection<TickerModel> Tickers { get; } = new();
    public ObservableCollection<OrderBookModel> OrderBooksModel { get; set; } = new();

    private List<(XOrderBookForm Form, OrderBookViewModel ViewModel)> formViewModelPairs = new List<(XOrderBookForm, OrderBookViewModel)>();
    
    public MainViewModel(IOrderBookApiService orderBookApiService, IDataProvider dataProvider)
    {
        _orderBookApiService = orderBookApiService;
        _dataProvider = dataProvider;
    }

    // Handle button click events and open the corresponding windows
    public void OpenOrderBookWindow()
    {
        var orderBookViewModel = new OrderBookViewModel(new OrderBookModel(), _orderBookApiService);

        var orderBookform = new XOrderBookForm(orderBookViewModel, Tickers);

        formViewModelPairs.Add((orderBookform, orderBookViewModel));

        orderBookform.FormClosed += (sender, e) =>
        {
            var closedForm = (XOrderBookForm)sender;
            var pair = formViewModelPairs.FirstOrDefault(x => x.Form == closedForm);
            if (pair != default)
            {
                formViewModelPairs.Remove(pair);
            }
        };

        orderBookform.Show();
    }

    public async Task Load()
    {
        OrderBooksModel = await _orderBookApiService.GetOrderBook();

        OrderBooks.Clear();

        foreach (var orderBook in OrderBooksModel)
        {
            OrderBooks.Add(new OrderBookViewModel(orderBook, _orderBookApiService));
        }

        var tickers = await _orderBookApiService.GetTicker();

        Tickers.Clear();

        foreach (var ticker in tickers)
        {
            Tickers.Add(ticker);
        }

    }
}
