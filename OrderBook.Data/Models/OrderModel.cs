using System;

namespace OrderBook.Data.Models;

public class OrderModel
{
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public string ProductType { get; set; }
    public DateTime Time { get; set; }

    public OrderModel()
    {
        Type = string.Empty;
        Price = 0;
        Quantity = 0;
        Total = 0;
        ProductType = string.Empty;
    }
}