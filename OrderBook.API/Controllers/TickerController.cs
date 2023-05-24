using Microsoft.AspNetCore.Mvc;
using OrderBook.API.Services.DataProvider;
using OrderBook.Data.Models;
using System.Collections.Generic;

namespace OrderBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TickerController : ControllerBase
{
    private readonly IDataProvider _dataProvider;

    public TickerController(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TickerModel>> Get()
    {
        return _dataProvider.Tickers;
    }
}
