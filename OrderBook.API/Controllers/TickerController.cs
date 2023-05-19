using Microsoft.AspNetCore.Mvc;
using OrderBook.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace OrderBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TickerController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<TickerModel>> Get()
    {
        List<TickerModel> listTickers = new List<TickerModel>
        {
            new TickerModel
            {
                Symbol = "GOOGL",
                ProductType = "Futures"
            },
            new TickerModel
            { 
                Symbol = "APPL",
                ProductType = "Options"
            },
        };

        return listTickers;
    }
}
