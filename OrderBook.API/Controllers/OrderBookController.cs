using Microsoft.AspNetCore.Mvc;
using OrderBook.Data.DataProvider;
using OrderBook.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrderBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderBookController : ControllerBase
{
    private readonly IDataProvider _dataProvider;

    public OrderBookController(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderBookModel>> Get()
    {
        var tt = _dataProvider.OrderBooks;
        return tt;
    }

    [HttpGet("byTicker/{tickerSymbol}")]
    public async Task<ActionResult<OrderBookModel>> GetByTicker(string tickerSymbol)
    {
        OrderBookModel orderBook = await _dataProvider.GetOrderBookByTicker(tickerSymbol) ?? new OrderBookModel();

        return orderBook;
    }
}
