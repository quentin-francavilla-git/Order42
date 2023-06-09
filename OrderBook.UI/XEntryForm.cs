﻿using DevExpress.XtraEditors;
using OrderBook.Data.Enums;
using OrderBook.Data.Models;
using OrderBook.UI.ViewModels;

namespace OrderBook.UI;

public partial class XEntryForm : DevExpress.XtraEditors.XtraForm
{
    private readonly EntryViewModel _viewModel;
    private readonly string _currentTicker;

    public XEntryForm(EntryViewModel viewModel, string currentTicker)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
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

        InitDropDownMenu(actionDropDown, new List<string>()
        {
            nameof(EnumAction.Ask),
            nameof(EnumAction.Bid)
        });
        InitDropDownMenu(productTypeDropDown, new List<string>()
        {
            nameof(EnumProductType.Options),
            nameof(EnumProductType.Futures),
            nameof(EnumProductType.Equities),
            nameof(EnumProductType.Bonds)
        });
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
    private async void placeOrderBtn_Click(object? sender, EventArgs e)
    {
        _viewModel.OrderPlaced -= placeOrderBtn_Click;

        await EntryOrderBtnAction(nameof(EnumEntryType.PlaceOrder));
    }

    private async void amendOrderBtn_Click(object? sender, EventArgs e)
    {
        _viewModel.OrderAmended -= amendOrderBtn_Click;

        await EntryOrderBtnAction(nameof(EnumEntryType.AmendOrder));
    }

    private async void cancelOrderBtn_Click(object? sender, EventArgs e)
    {
        _viewModel.OrderCanceled -= cancelOrderBtn_Click;

        await EntryOrderBtnAction(nameof(EnumEntryType.CancelOrder));
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
        string messageBox = HandleInputError(price, quantity, selectedAction, selectedEntryType);

        if (!string.IsNullOrEmpty(messageBox))
        {
            MessageBox.Show(messageBox);
            return;
        }

        if (selectedEntryType == nameof(EnumEntryType.CancelOrder))
            quantity = "0";

        // Call the EntryOrder 
        int resultCode = await _viewModel.EntryOrder(
            new OrderModel()
            {
                Type = selectedAction,
                Price = decimal.Parse(price),
                Quantity = int.Parse(quantity),
                ProductType = selectedProductType,
                Time = DateTime.Now,
            },
            _currentTicker,
            selectedEntryType);

        // Error and message handling
        messageBox = HandleCodeError(resultCode, selectedEntryType);

        MessageBox.Show(messageBox);
    }

    private string HandleInputError(string price, string quantity, string selectedAction, string selectedEntryType)
    {
        string messageBox = string.Empty;

        if (string.IsNullOrEmpty(price) || !decimal.TryParse(price, out _))
        {
            messageBox = "Enter valid price.";
        }
        else if ((string.IsNullOrEmpty(quantity) || !int.TryParse(quantity, out _))
            && selectedEntryType != nameof(EnumEntryType.CancelOrder))
        {
            messageBox = "Enter valid quantity.";
        }
        else if (string.IsNullOrEmpty(selectedAction))
        {
            messageBox = "Invalid Ticker.";
        }

        return messageBox;
    }

    private string HandleCodeError(int resultCode, string selectedEntryType)
    {
        string messageBox = string.Empty;

        if (resultCode == 1)
        {
            if (selectedEntryType == nameof(EnumEntryType.PlaceOrder))
                messageBox = "Order already existing. Updated successfully.";
            else if (selectedEntryType == nameof(EnumEntryType.AmendOrder))
                messageBox = "Order updated successfully.";
            else if (selectedEntryType == nameof(EnumEntryType.CancelOrder))
                messageBox = "Order canceled successfully.";
        }
        else if (resultCode == 2)
        {
            if (selectedEntryType == nameof(EnumEntryType.PlaceOrder))
                messageBox = "New Order placed successfully.";
            else
                messageBox = "Error: No Order corresponding.";
        }
        else
        {
            messageBox = "Error while placing the order.";
        }

        return messageBox;
    }
}