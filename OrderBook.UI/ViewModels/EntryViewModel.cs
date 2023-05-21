using OrderBook.Data.Models;
using OrderBook.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook.UI.ViewModels;

public class EntryViewModel : ViewModelBase
{
    private readonly IOrderBookApiService _orderBookApiService;
    public event EventHandler OrderPlaced;
    public event EventHandler OrderAmended;
    public event EventHandler OrderCanceled;
    private List<string> _action;
    private string _quantity = "";
    private string _price = "";

    public EntryViewModel(IOrderBookApiService orderBookApiService)
    {
        _orderBookApiService = orderBookApiService;
        _action = new List<string>();
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

    //// Place Order
    protected virtual void OnOrderPlaced(EventArgs e)
    {
        OrderPlaced?.Invoke(this, e);
    }

    //public async Task<int> PlaceOrder(OrderModel order, string symbol)
    //{
    //    int resultCode = await _orderBookApiService.PlaceOrder(order, symbol);

    //    OnOrderPlaced(EventArgs.Empty);

    //    return resultCode;
    //}

    //// Amend order

    protected virtual void OnOrderAmended(EventArgs e)
    {
        OrderAmended?.Invoke(this, e);
    }

    //public async Task<int> AmendOrder(OrderModel order, string symbol)
    //{
    //    int resultCode = await _orderBookApiService.AmendOrder(order, symbol);

    //    OnOrderAmended(EventArgs.Empty);

    //    return resultCode;
    //}

    //// Cancel Order
    protected virtual void OnOrderCanceled(EventArgs e)
    {
        OrderCanceled?.Invoke(this, e);
    }

    //public async Task<int> CancelOrder(OrderModel order, string symbol)
    //{
    //    int resultCode = await _orderBookApiService.CancelOrder(order, symbol);

    //    OnOrderCanceled(EventArgs.Empty);

    //    return resultCode;
    //}


    public async Task<int> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        int resultCode = await _orderBookApiService.EntryOrder(order, symbol, entryType);

        if (entryType == "PlaceOrder")
            OnOrderPlaced(EventArgs.Empty);
        if (entryType == "AmendOrder")
            OnOrderAmended(EventArgs.Empty);
        if (entryType == "CancelOrder")
            OnOrderCanceled(EventArgs.Empty);

        return resultCode;
    }


}
