using System.Collections.Generic;

namespace OrderBook.Data.Models;

public class OrderBookModel
{
    public TickerModel Ticker { get; set; }
    public List<OrderModel> Bids { get; set; }
    public List<OrderModel> Asks { get; set; }
}