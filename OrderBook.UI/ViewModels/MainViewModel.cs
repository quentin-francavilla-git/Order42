using OrderBook.API.Services.ApiBridge;
using OrderBook.Data.Models;
using OrderBook.UI.Helpers.ErrorHandler;
using System.Collections.ObjectModel;

namespace OrderBook.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IApiBridge _apiBridge;
    public List<OrderBookViewModel> OrderBooks { get; } = new();
    public List<TickerModel> Tickers { get; } = new();

    private readonly List<(XOrderBookForm Form, OrderBookViewModel ViewModel)> formViewModelPairs = new();
    
    public MainViewModel(IApiBridge apiBridge)
    {
        _apiBridge = apiBridge;
        ErrorHandlerService.ErrorOccurred += ErrorHandlerService_ErrorOccurred;
    }

    // Handle button click events and open the orderbook window
    public async Task OpenOrderBookWindow()
    {
        var connectionCode = await Load();

        if (connectionCode == 42)
            return;

        var orderBookViewModel = new OrderBookViewModel(new OrderBookModel(), _apiBridge);

        var orderBookform = new XOrderBookForm(orderBookViewModel, Tickers);

        formViewModelPairs.Add((orderBookform, orderBookViewModel));

        orderBookform.FormClosed += (sender, e) =>
        {
            if (sender is XOrderBookForm closedForm)
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
        var tickers = await _apiBridge.GetTicker();

        Tickers.Clear();

        if (tickers == null)
        {
            return 42;
        }

        if (tickers.Count <= 0)
        {
            ErrorHandlerService.RaiseError("Could not load file \"OrderBook.Data\\JsonData\\ticker.json\".");
            return 42;
        }

        foreach (var ticker in tickers)
        {
            Tickers.Add(ticker);
        }
        return 0;
    }
}
