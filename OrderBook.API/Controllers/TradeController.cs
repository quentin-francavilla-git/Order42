using Microsoft.AspNetCore.Mvc;
using OrderBook.API.Services.DataProvider;
using OrderBook.Data.Models;
using System.Collections.Generic;

namespace OrderBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TradeController : ControllerBase
{
    private readonly IDataProvider _dataProvider;

    public TradeController(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TradeModel>> Get()
    {
        return _dataProvider.Trades;
    }
}