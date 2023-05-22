using OrderBook.Data.Models;
using OrderBook.Data.Services;
using OrderBook.UI.Helpers.ErrorHandler;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private IOrderBookApiService _orderBookApiService;
    public ObservableCollection<OrderBookViewModel> OrderBooks { get; } = new();
    public ObservableCollection<TickerModel> Tickers { get; } = new();

    private List<(XOrderBookForm Form, OrderBookViewModel ViewModel)> formViewModelPairs = new List<(XOrderBookForm, OrderBookViewModel)>();
    
    public MainViewModel(IOrderBookApiService orderBookApiService)
    {
        _orderBookApiService = orderBookApiService;
        ErrorHandlerService.ErrorOccurred += ErrorHandlerService_ErrorOccurred;
    }

    // Handle button click events and open the orderbook window
    public async Task OpenOrderBookWindow()
    {
        var connectionCode = await Load();

        if (connectionCode == 42)
            return;

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

    public async Task<int> Load()
    {
        // Loading tickers list at the start cause this value wont change frequently
        var tickers = await _orderBookApiService.GetTicker();

        Tickers.Clear();

        if (tickers == null)
            return 42;

        foreach (var ticker in tickers)
        {
            Tickers.Add(ticker);
        }
        return 0;
    }

    public async Task Refresh()
    {
        _orderBookApiService = new OrderBookApiService();
        await Load();
    }
}
