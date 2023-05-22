using System.Collections.Generic;

namespace OrderBook.Data.Models;

public class OrderBookModel
{
    public TickerModel Ticker { get; set; }
    public List<OrderModel> Bids { get; set; }
    public List<OrderModel> Asks { get; set; }

    public OrderBookModel()
    {
        Ticker = new TickerModel();
        Bids = new List<OrderModel>();
        Asks = new List<OrderModel>();
    }
}
