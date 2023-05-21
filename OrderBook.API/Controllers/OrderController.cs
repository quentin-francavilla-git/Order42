﻿using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("placeOrder")]
    public async Task<IActionResult> PlaceOrder(OrderModel order, string symbol)
    {
        int resultCode = await _dataProvider.PlaceOrder(order, symbol);
        return Ok(resultCode);
    }

    [HttpPost("amendOrder")]
    public async Task<IActionResult> AmendOrder(OrderModel order, string symbol)
    {
        int resultCode = await _dataProvider.AmendOrder(order, symbol);
        return Ok(resultCode);
    }
}
