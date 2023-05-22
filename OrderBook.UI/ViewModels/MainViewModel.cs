using OrderBook.Data.DataProvider;
using OrderBook.Data.Models;
using OrderBook.Data.Services;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;
    public ObservableCollection<OrderBookViewModel> OrderBooks { get; } = new();
    public ObservableCollection<TickerModel> Tickers { get; } = new();

    private List<(XOrderBookForm Form, OrderBookViewModel ViewModel)> formViewModelPairs = new List<(XOrderBookForm, OrderBookViewModel)>();
    
    public MainViewModel(IOrderBookApiService orderBookApiService)
    {
        _orderBookApiService = orderBookApiService;
    }

    // Handle button click events and open the corresponding windows
    public async Task OpenOrderBookWindow()
    {
        await Load();
        var orderBookViewModel = new OrderBookViewModel(new OrderBookModel(), _orderBookApiService);

        var orderBookform = new XOrderBookForm(orderBookViewModel, Tickers);

        formViewModelPairs.Add((orderBookform, orderBookViewModel));

        orderBookform.FormClosed += (sender, e) =>
        {
            var closedForm = sender as XOrderBookForm;
            if (closedForm != null)
            {
                var pair = formViewModelPairs.FirstOrDefault(x => x.Form == closedForm);
                if (pair != default)
                {
                    formViewModelPairs.Remove(pair);
                }
            }
        };
        orderBookform.Show();
    }

    public async Task Load()
    {
        // get existing orderbooks
        await _orderBookApiService.GetInitialOrderBooks();

        // Choice of loading tickers list at the start considering this value wont change frequently
        var tickers = await _orderBookApiService.GetTicker();

        Tickers.Clear();

        foreach (var ticker in tickers)
        {
            Tickers.Add(ticker);
        }

    }
}
