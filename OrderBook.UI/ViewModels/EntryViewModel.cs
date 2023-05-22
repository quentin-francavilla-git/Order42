using OrderBook.Data.Enums;
using OrderBook.Data.Models;
using OrderBook.Data.Services;

namespace OrderBook.UI.ViewModels;

public class EntryViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;

    public event EventHandler OrderPlaced = delegate { };
    public event EventHandler OrderAmended = delegate { };
    public event EventHandler OrderCanceled = delegate { };

    private List<string> _action;
    private string _quantity;
    private string _price;

    public EntryViewModel(IOrderBookApiService orderBookApiService)
    {
        _orderBookApiService = orderBookApiService;
        _action = new List<string>();
        _price = string.Empty;
        _quantity = string.Empty;
    }

    public List<string> Action
    {
        get => _action;
        set
        {
            if (!Enumerable.SequenceEqual(_action, value))
            {
                _action = value;
                RaisePropertyChanged();
            }
        }
    }

    public string Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            RaisePropertyChanged();
        }
    }

    public string Price
    {
        get => _price;
        set
        {
            _price = value;
            RaisePropertyChanged();
        }
    }

    // Place Order
    protected virtual void OnOrderPlaced(EventArgs e)
    {
        OrderPlaced?.Invoke(this, e);
    }

    // Amend order
    protected virtual void OnOrderAmended(EventArgs e)
    {
        OrderAmended?.Invoke(this, e);
    }

    // Cancel Order
    protected virtual void OnOrderCanceled(EventArgs e)
    {
        OrderCanceled?.Invoke(this, e);
    }

    public async Task<int> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        int resultCode = await _orderBookApiService.EntryOrder(order, symbol, entryType);

        // Raise the correct event
        if (entryType == nameof(EnumEntryType.PlaceOrder))
            OnOrderPlaced(EventArgs.Empty);
        if (entryType == nameof(EnumEntryType.AmendOrder))
            OnOrderAmended(EventArgs.Empty);
        if (entryType == nameof(EnumEntryType.CancelOrder))
            OnOrderCanceled(EventArgs.Empty);

        return resultCode;
    }


}
