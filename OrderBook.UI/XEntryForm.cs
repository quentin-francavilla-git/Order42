﻿using DevExpress.XtraEditors;
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
        _currentTicker = currentTicker;
    }

    private void XEntryForm_Load(object sender, EventArgs e)
    {
        BindingDropDownToViewModel(actionDropDown, nameof(System.Windows.Forms.ComboBox.SelectedItem), nameof(_viewModel.Action));
        BindingTextBoxToViewModel(quantityTextBox, nameof(TextBox.Text), nameof(_viewModel.Quantity));
        BindingTextBoxToViewModel(priceTextBox, nameof(TextBox.Text), nameof(_viewModel.Price));

        InitDropDownMenu(actionDropDown, new List<string>() { "Ask", "Bid" });
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

        string selectedItem = actionDropDown.SelectedItem?.ToString() ?? string.Empty;

        string price = priceTextBox.Text;

        if (price == null)
        {
            MessageBox.Show("Enter valid price.");
            return;
        }
        if (!decimal.TryParse(price, out _))
        {
            MessageBox.Show("Enter valid price.");
            return;
        }

        string quantity = quantityTextBox.Text;

        if (quantity == null)
        {
            MessageBox.Show("Enter valid quantity.");
            return;
        }
        if (!int.TryParse(quantity, out _))
        {
            MessageBox.Show("Enter valid quantity.");
            return;
        }

        if (selectedItem == null)
        {
            MessageBox.Show("Invalid Ticker.");
            return;
        }

        int resultCode = await _viewModel.PlaceOrder(
            new OrderModel()
            {
                Type = selectedItem,
                Price = decimal.Parse(price),
                Quantity = int.Parse(quantity),
                ProductType = "Options"
            },
            _currentTicker);

        if (resultCode == 1)
            MessageBox.Show("Order already existing. Updated successfully.");
        else if (resultCode == 2)
            MessageBox.Show("New Order placed successfully.");
        else
            MessageBox.Show("Error while placing the order.");

        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }

    private async void amendOrderBtn_Click(object sender, EventArgs e)
    {
        _viewModel.OrderAmended -= amendOrderBtn_Click;

        string selectedItem = actionDropDown.SelectedItem?.ToString() ?? string.Empty;

        string price = priceTextBox.Text;

        if (price == null)
        {
            MessageBox.Show("Enter valid price.");
            return;
        }
        if (!decimal.TryParse(price, out _))
        {
            MessageBox.Show("Enter valid price.");
            return;
        }

        string quantity = quantityTextBox.Text;

        if (quantity == null)
        {
            MessageBox.Show("Enter valid quantity.");
            return;
        }
        if (!int.TryParse(quantity, out _))
        {
            MessageBox.Show("Enter valid quantity.");
            return;
        }

        if (selectedItem == null)
        {
            MessageBox.Show("Invalid Ticker.");
            return;
        }

        int resultCode = await _viewModel.AmendOrder(
            new OrderModel()
            {
                Type = selectedItem,
                Price = decimal.Parse(price),
                Quantity = int.Parse(quantity),
                ProductType = "Options"
            },
            _currentTicker);

        if (resultCode == 1)
            MessageBox.Show("Order updated successfully.");
        else if (resultCode == 2)
            MessageBox.Show("Error : No Order corresponding.");
        else
            MessageBox.Show("Error while amending the order.");

        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }
}