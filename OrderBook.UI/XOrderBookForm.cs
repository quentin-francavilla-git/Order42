using OrderBook.Data.Models;
using OrderBook.UI.Helpers.ErrorHandler;
using OrderBook.UI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace OrderBook.UI;

public partial class XOrderBookForm : DevExpress.XtraEditors.XtraForm
{
    private readonly OrderBookViewModel _orderBookViewModel;
    private readonly List<TickerModel> _listOfTicker;

    public XOrderBookForm(OrderBookViewModel viewModel, List<TickerModel> listOfTicker)
    {
        InitializeComponent();
        _orderBookViewModel = viewModel;
        DataContext = _orderBookViewModel;
        _listOfTicker = listOfTicker;
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
    private void InitDropDownMenu(ComboBox dropDownButton, List<TickerModel> listOfTicker)
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

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(OrderModel.Time),
            HeaderText = "Time/Date",
            Name = "Time/Date"
        });

        dataGridView.Columns["Product"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        dataGridView.DataSource = bindingSource;
    }

    // Events
    private async void tickerDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tickerDropDown.SelectedItem is TickerModel selectedTicker)
        {
            await _orderBookViewModel.LoadOrderBookByTicker(selectedTicker.Symbol);
            SetDateRange();
        }
    }

    private void entryOrderbtn_Click(object sender, EventArgs e)
    {
        _orderBookViewModel.OpenEntryForm();
    }

    private async void refreshButton_Click(object sender, EventArgs e)
    {
        if (tickerDropDown.SelectedItem is TickerModel selectedTicker)
        {
            await _orderBookViewModel.LoadOrderBookByTicker(selectedTicker.Symbol);
        }
        SetDateRange();
    }

    private void datePicker_ValueChanged(object sender, EventArgs e)
    {
        SetDateRange();
    }

    private void SetDateRange()
    {
        DateTime startDate = fromDatePicker.Value;
        DateTime endDate = toDatePicker.Value;

        if (dataGridAsks.BindingContext == null || dataGridBids.BindingContext == null)
        {
            ErrorHandlerService.RaiseError("BindingContext is null.");
            return;
        }

        CurrencyManager currencyManager = (CurrencyManager)dataGridAsks.BindingContext[dataGridAsks.DataSource];
        currencyManager.SuspendBinding();

        // Asks
        foreach (DataGridViewRow row in dataGridAsks.Rows)
        {
            if (!row.IsNewRow)
            {
                DateTime rowDateTime = Convert.ToDateTime(row.Cells["Time/Date"].Value);
                row.Visible = (rowDateTime >= startDate && rowDateTime <= endDate);
            }
        }

        currencyManager.ResumeBinding();

        // Bids
        currencyManager = (CurrencyManager)dataGridBids.BindingContext[dataGridBids.DataSource];
        currencyManager.SuspendBinding();

        foreach (DataGridViewRow row in dataGridBids.Rows)
        {
            if (!row.IsNewRow)
            {
                DateTime rowDateTime = Convert.ToDateTime(row.Cells["Time/Date"].Value);
                row.Visible = (rowDateTime >= startDate && rowDateTime <= endDate);
            }
        }

        currencyManager.ResumeBinding();
    }
}