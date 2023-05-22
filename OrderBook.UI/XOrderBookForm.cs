using DevExpress.XtraDiagram.Base;
using OrderBook.Data.Models;
using OrderBook.Data.Services;
using OrderBook.UI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace OrderBook.UI;

public partial class XOrderBookForm : DevExpress.XtraEditors.XtraForm
{
    private readonly OrderBookViewModel _orderBookViewModel;
    private readonly ObservableCollection<TickerModel> _listOfTicker;
    private readonly IOrderBookApiService _orderBookApiService;

    public XOrderBookForm(OrderBookViewModel viewModel, ObservableCollection<TickerModel> listOfTicker, IOrderBookApiService orderBookApiService)
    {
        InitializeComponent();
        _orderBookViewModel = viewModel;
        DataContext = _orderBookViewModel;
        _listOfTicker = listOfTicker;
        _orderBookApiService = orderBookApiService;
        _orderBookApiService.DataUpdated += RefreshData;
    }

    private async void XOrderBookForm_Load(object sender, EventArgs e)
    {
        BindingGridToViewModel(dataGridAsks, nameof(DataGridView.DataSource), "Asks");
        BindingGridToViewModel(dataGridBids, nameof(DataGridView.DataSource), "Bids");
        BindingDropDownToViewModel(tickerDropDown, nameof(ComboBox.SelectedItem), "Ticker");

        if (_listOfTicker.Any())
        {
            await _orderBookViewModel.LoadOrderBookByTicker(_listOfTicker.First().Symbol);
        }

        InitGridView(dataGridAsks, _orderBookViewModel.Asks);
        InitGridView(dataGridBids, _orderBookViewModel.Bids);
        InitDropDownMenu(tickerDropDown, _listOfTicker);
    }

    // Binding data
    private void BindingGridToViewModel(DataGridView gridView, string property, string dataMember)
    {
        gridView.DataBindings.Add(property, _orderBookViewModel, dataMember);
    }

    private void BindingDropDownToViewModel(ComboBox comboBox, string property, string dataMember)
    {
        comboBox.DataBindings.Add(property, _orderBookViewModel, dataMember);
    }

    // Init controls
    private void InitDropDownMenu(ComboBox dropDownButton, ObservableCollection<TickerModel> listOfTicker)
    {
        dropDownButton.DataSource = listOfTicker;
        dropDownButton.DisplayMember = nameof(TickerModel.Symbol);
        dropDownButton.ValueMember = nameof(TickerModel.Symbol);
    }

    private void InitGridView(DataGridView dataGridView, List<OrderModel> listOfOrder)
    {
        var bindingList = new BindingList<OrderModel>(listOfOrder);
        var bindingSource = new BindingSource(bindingList, null);

        dataGridView.AutoGenerateColumns = false;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dataGridView.Columns.Clear();

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Price),
            HeaderText = "Price",
            Name = "Price"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Quantity),
            HeaderText = "Quantity",
            Name = "Quantity"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Total),
            HeaderText = "Total",
            Name = "Total"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.ProductType),
            HeaderText = "Product",
            Name = "Product"
        });

        dataGridView.DataSource = bindingSource;
    }

    // Other methods
    public async void RefreshData(object? sender, EventArgs e)
    {
        await _orderBookViewModel.LoadOrderBookByTicker(_orderBookViewModel.OrderBook.Ticker.Symbol);
    }

    // Events
    private async void tickerDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tickerDropDown.SelectedItem is TickerModel selectedTicker)
        {
            await _orderBookViewModel.LoadOrderBookByTicker(selectedTicker.Symbol);
        }
    }

    private void entryOrderbtn_Click(object sender, EventArgs e)
    {
        _orderBookViewModel.OpenEntryForm();
    }
}