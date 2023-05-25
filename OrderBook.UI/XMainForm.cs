using OrderBook.UI.ViewModels;
using OrderBook.API.Services.ApiBridge;

namespace OrderBook.UI
{
    public partial class XMainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly MainViewModel _mainViewModel;

        public XMainForm()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel(new ApiBridge());
        }
        private void XMainForm_Load(object sender, EventArgs e)
        {
            orderBookBindingSource.DataSource = _mainViewModel.OrderBooks;
        }

        private async void btnOpenOrderBookForm_Click(object sender, EventArgs e)
        {
            await _mainViewModel.OpenOrderBookWindow();
        }


        private async void openTradeFormBtn_Click(object sender, EventArgs e)
        {
            await _mainViewModel.OpenTradesHistoryWindow();
        }
    }
}