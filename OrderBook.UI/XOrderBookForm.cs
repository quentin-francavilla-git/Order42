using DevExpress.DataProcessing;
using DevExpress.Utils.Extensions;
using OrderBook.Data;
using OrderBook.Data.Models;
using OrderBook.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OrderBook.UI;

public partial class XOrderBookForm : DevExpress.XtraEditors.XtraForm
{
    private readonly OrderBookViewModel _orderBookViewModel;
    private readonly ObservableCollection<TickerModel> _listOfTicker;

    public XOrderBookForm(OrderBookViewModel viewModel, ObservableCollection<TickerModel> listOfTicker)
    {
        InitializeComponent();
        _orderBookViewModel = viewModel;
        DataContext = _orderBookViewModel;
        _listOfTicker = listOfTicker;
    }

    private void XOrderBookForm_Load(object sender, EventArgs e)
    {
        BindingGridToViewModel(dataGridAsks, nameof(DataGridView.DataSource), "Asks");
        BindingGridToViewModel(dataGridBids, nameof(DataGridView.DataSource), "Bids");
        BindingDropDownToViewModel(tickerDropDown, nameof(System.Windows.Forms.ComboBox.SelectedItem), "Ticker");

        InitGridView(dataGridAsks, _orderBookViewModel.Asks);
        InitGridView(dataGridBids, _orderBookViewModel.Bids);
        InitDropDownMenu(tickerDropDown, _listOfTicker);
    }

    private void InitDropDownMenu(System.Windows.Forms.ComboBox dropDownButton, ObservableCollection<TickerModel> listOfTicker)
    {
        dropDownButton.DataSource = listOfTicker;
        dropDownButton.DisplayMember = nameof(TickerModel.Symbol);
        dropDownButton.ValueMember = nameof(TickerModel.Symbol);
    }

    private void BindingGridToViewModel(DataGridView gridView, string property, string dataMember)
    {
        gridView.DataBindings.Add(property, _orderBookViewModel, dataMember);
    }

    private void BindingDropDownToViewModel(System.Windows.Forms.ComboBox comboBox, string property, string dataMember)
    {
        comboBox.DataBindings.Add(property, _orderBookViewModel, dataMember);
    }

    private void InitGridView(DataGridView dataGridView, List<OrderModel> listOfOrder)
    {
        var sourceList = new List<OrderModel>();

        sourceList.AddRange(listOfOrder);

        dataGridView.AutoGenerateColumns = false;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dataGridView.Columns.Clear();

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Quantity),
            HeaderText = "Quantity"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Price),
            HeaderText = "Price"
        });

        dataGridView.DataSource = sourceList;
    }

    private async void tickerDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tickerDropDown.SelectedItem is TickerModel selectedTicker)
        {
            await _orderBookViewModel.LoadOrderBookByTicker(selectedTicker.Symbol);
        }
    }
}