using Microsoft.AspNetCore.Mvc;
using OrderBook.Data.DataProvider;
using OrderBook.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IDataProvider _dataProvider;

    public OrderController(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    [HttpPost("entryOrder")]
    public async Task<IActionResult> EntryOrder(OrderModel order, string symbol, string entryType)
    {
        int resultCode = await _dataProvider.EntryOrder(order, symbol, entryType);
        return Ok(resultCode);
    }
}
