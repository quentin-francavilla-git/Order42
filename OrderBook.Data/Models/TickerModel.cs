namespace OrderBook.Data.Models;

public class TickerModel
{
    public string Symbol { get; set; }

    public TickerModel()
    {
        Symbol = string.Empty;
    }
}