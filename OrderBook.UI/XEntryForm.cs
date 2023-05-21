using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using OrderBook.Data.Models;
using OrderBook.UI.ViewModels;
using System.Collections.ObjectModel;

namespace OrderBook.UI;

public partial class XEntryForm : DevExpress.XtraEditors.XtraForm
{
    private readonly EntryViewModel _viewModel;
    private readonly OrderBookViewModel _orderBookViewModel;
    private readonly string _currentTicker;

    public XEntryForm(EntryViewModel viewModel, OrderBookViewModel orderBookViewModel, string currentTicker)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
        _orderBookViewModel = orderBookViewModel;
        _viewModel.OrderPlaced += placeOrderBtn_Click;
        _viewModel.OrderAmended += amendOrderBtn_Click;
        _viewModel.OrderCanceled += cancelOrderBtn_Click;
        _currentTicker = currentTicker;
    }

    private void XEntryForm_Load(object sender, EventArgs e)
    {
        BindingDropDownToViewModel(actionDropDown, nameof(System.Windows.Forms.ComboBox.SelectedItem), nameof(_viewModel.Action));
        BindingTextBoxToViewModel(quantityTextBox, nameof(TextBox.Text), nameof(_viewModel.Quantity));
        BindingTextBoxToViewModel(priceTextBox, nameof(TextBox.Text), nameof(_viewModel.Price));

        InitDropDownMenu(actionDropDown, new List<string>() { "Ask", "Bid" });
        InitDropDownMenu(productTypeDropDown, new List<string>() { "Options", "Futures", "Equities", "Bonds" });
        InitLabel(tickerLabel, _currentTicker);
    }

    // Init controls
    private void InitDropDownMenu(System.Windows.Forms.ComboBox dropDownButton, List<string> listOfItems)
    {
        dropDownButton.DataSource = listOfItems;
        dropDownButton.DisplayMember = "ToString";
    }
    private void InitLabel(LabelControl label, string text)
    {
        label.Text = text;
    }

    // Binding data
    private void BindingDropDownToViewModel(System.Windows.Forms.ComboBox comboBox, string property, string dataMember)
    {
        comboBox.DataBindings.Add(property, _viewModel, dataMember);
    }
    private void BindingTextBoxToViewModel(TextBox textBox, string property, string dataMember)
    {
        textBox.DataBindings.Add(property, _viewModel, dataMember);
    }


    // Events
    private async void placeOrderBtn_Click(object sender, EventArgs e)
    {
        _viewModel.OrderPlaced -= placeOrderBtn_Click;

        await EntryOrderBtnAction("PlaceOrder");

        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }

    private async void amendOrderBtn_Click(object sender, EventArgs e)
    {
        _viewModel.OrderAmended -= amendOrderBtn_Click;

        await EntryOrderBtnAction("AmendOrder");

        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }

    private async void cancelOrderBtn_Click(object sender, EventArgs e)
    {
        _viewModel.OrderCanceled -= cancelOrderBtn_Click;

        await EntryOrderBtnAction("CancelOrder");

        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }

    public async Task EntryOrderBtnAction(string selectedEntryType)
    {
        // Drop Down values
        string selectedAction = actionDropDown.SelectedItem?.ToString() ?? string.Empty;
        string selectedProductType = productTypeDropDown.SelectedItem?.ToString() ?? string.Empty;

        // Textboxes values
        string price = priceTextBox.Text;
        string quantity = quantityTextBox.Text;

        // Handling wrong inputs
        string messageBox = string.Empty;

        if (string.IsNullOrEmpty(price) || !decimal.TryParse(price, out _))
        {
            messageBox = "Enter valid price.";
        }
        else if (string.IsNullOrEmpty(quantity) || !int.TryParse(quantity, out _))
        {
            messageBox = "Enter valid quantity.";
        }
        else if (string.IsNullOrEmpty(selectedAction))
        {
            messageBox = "Invalid Ticker.";
        }

        if (!string.IsNullOrEmpty(messageBox))
        {
            MessageBox.Show(messageBox);
            return;
        }

        // Call the EntryOrder 
        int resultCode = await _viewModel.EntryOrder(
            new OrderModel()
            {
                Type = selectedAction,
                Price = decimal.Parse(price),
                Quantity = int.Parse(quantity),
                ProductType = selectedProductType
            },
            _currentTicker,
            selectedEntryType);

        // Error and message handling

        if (resultCode == 1)
        {
            if (selectedEntryType == "PlaceOrder")
                messageBox = "Order already existing. Updated successfully.";
            else if (selectedEntryType == "AmendOrder")
                messageBox = "Order updated successfully.";
            else if (selectedEntryType == "CancelOrder")
                messageBox = "Order canceled successfully.";
        }
        else if (resultCode == 2)
        {
            if (selectedEntryType == "PlaceOrder")
                messageBox = "New Order placed successfully.";
            else
                messageBox = "Error: No Order corresponding.";
        }
        else
        {
            messageBox = "Error while placing the order.";
        }

        MessageBox.Show(messageBox);
    }
}