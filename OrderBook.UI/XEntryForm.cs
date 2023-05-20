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
        _viewModel.OrderPlaced += placeBtn_Click;
        _currentTicker = currentTicker;
    }

    private async void XEntryForm_Load(object sender, EventArgs e)
    {
        BindingDropDownToViewModel(actionDropDown, nameof(ComboBox.SelectedItem), nameof(_viewModel.Action));
        BindingTextBoxToViewModel(quantityTextBox, nameof(TextBox.Text), nameof(_viewModel.Quantity));
        BindingTextBoxToViewModel(priceTextBox, nameof(TextBox.Text), nameof(_viewModel.Price));

        InitDropDownMenu(actionDropDown, new List<string>() { "Ask", "Bid" });
    }

    // Init controls
    private void InitDropDownMenu(ComboBox dropDownButton, List<string> listOfItems)
    {
        dropDownButton.DataSource = listOfItems;
        dropDownButton.DisplayMember = "ToString";
    }

    // Binding data
    private void BindingDropDownToViewModel(ComboBox comboBox, string property, string dataMember)
    {
        comboBox.DataBindings.Add(property, _viewModel, dataMember);
    }
    private void BindingTextBoxToViewModel(TextBox textBox, string property, string dataMember)
    {
        textBox.DataBindings.Add(property, _viewModel, dataMember);
    }


    // Events
    private async void placeBtn_Click(object sender, EventArgs e)
    {
        _viewModel.OrderPlaced -= placeBtn_Click;

        string selectedItem = actionDropDown.SelectedItem.ToString();
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

        await _viewModel.PlaceOrder(
            new OrderModel()
            {
                Type = selectedItem,
                Price = decimal.Parse(price),
                Quantity = int.Parse(quantity),
                ProductType = "Options"
            },
            _currentTicker);
        MessageBox.Show("Order placed successfully.");
        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }
}