using System;

namespace OrderBook.Data.Models;

public class TradeModel
{
    public DateTime Time { get; set; }
    public string Side { get; set; }
    public string Ticker { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductType { get; set; }

    public TradeModel()
    {
        Side = string.Empty;
        Ticker = string.Empty;
        Quantity = 0;
        Price = 0;
        ProductType = string.Empty;
    }
}
