using OrderBook.Data;
using OrderBook.UI.ViewModels;

namespace OrderBook.UI
{
    public partial class XMainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly MainViewModel _mainViewModel;

        public XMainForm()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel(new OrderBookApiService(), new DataProvider());
        }

        private void btnOpenOrderBookForm_Click(object sender, EventArgs e)
        {
            _mainViewModel.OpenOrderBookWindow();
        }

        private async void XMainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await _mainViewModel.Load();
            orderBookBindingSource.DataSource = _mainViewModel.OrderBooks;
        }
    }
}