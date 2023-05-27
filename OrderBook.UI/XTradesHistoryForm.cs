using OrderBook.Data.Models;
using System.ComponentModel;

namespace OrderBook.UI;

public partial class XTradesHistoryForm : DevExpress.XtraEditors.XtraForm
{
    private readonly List<TradeModel> _trades;

    public XTradesHistoryForm(List<TradeModel> trades)
    {
        InitializeComponent();
        _trades = trades;
        DataContext = _trades;
    }

    private void XTradesHistory_Load(object sender, EventArgs e)
    {
        InitGridView(tradeHistoryDataGrid, _trades);
    }

    private void InitGridView(DataGridView dataGridView, List<TradeModel> listOfTrades)
    {
        var bindingList = new BindingList<TradeModel>(listOfTrades);
        var bindingSource = new BindingSource(bindingList, null);

        dataGridView.AutoGenerateColumns = false;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dataGridView.Columns.Clear();

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.Time),
            HeaderText = "Time/Date",
            Name = "Time/Date"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.Side),
            HeaderText = "Side",
            Name = "Side"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.Ticker),
            HeaderText = "Side",
            Name = "Side"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.Price),
            HeaderText = "Price",
            Name = "Price"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.Quantity),
            HeaderText = "Quantity",
            Name = "Quantity"
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(TradeModel.ProductType),
            HeaderText = "Product",
            Name = "Product"
        });


        dataGridView.Columns["Product"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        dataGridView.DataSource = bindingSource;

        dataGridView.CellFormatting += (sender, e) =>
        {
            if (e.RowIndex >= 0)
            {
                var trade = dataGridView.Rows[e.RowIndex].DataBoundItem as TradeModel;
                if (trade != null)
                {
                    if (trade.Side == "BUY")
                    {
                        if (e.CellStyle != null)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(103, 227, 77);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(127, 236, 104);
                        }
                    }
                    else if (trade.Side == "SELL")
                    {
                        if (e.CellStyle != null)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(233, 54, 54);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(248, 87, 87);
                        }
                    }
                }
            }
        };
    }
}