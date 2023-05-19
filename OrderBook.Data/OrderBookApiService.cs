﻿using OrderBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderBook.Data;

public class OrderBookApiService : IOrderBookApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7228";

    public OrderBookApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<ObservableCollection<OrderBookModel>> GetOrderBook()
    {
        var response = await _httpClient.GetAsync("api/orderbook");
        response.EnsureSuccessStatusCode();

        var orderBooks = await response.Content.ReadFromJsonAsync<ObservableCollection<OrderBookModel>>();

        return orderBooks;
    }

    public async Task<IEnumerable<TickerModel>> GetTicker()
    {
        var response = await _httpClient.GetAsync("api/ticker");
        response.EnsureSuccessStatusCode();

        var tickers = await response.Content.ReadFromJsonAsync<IEnumerable<TickerModel>>();

        return tickers;
    }
    public async Task<OrderBookModel> GetOrderBookByTicker(string tickerSymbol)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/orderbook/byTicker/{tickerSymbol}");
            response.EnsureSuccessStatusCode();

            var orderBook = await response.Content.ReadFromJsonAsync<OrderBookModel>();
            return orderBook;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("An error occurred while making the HTTP request: " + ex.Message);
        }
        catch (JsonException ex)
        {
            Console.WriteLine("An error occurred while parsing the JSON response: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }

        return new OrderBookModel
        {
            Ticker = new TickerModel
            {
                Symbol = "No Data",
                ProductType = "No Data"
            },
            Bids = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 0,
                        Quantity = 0,
                    }
                },
            Asks = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Price = 0,
                        Quantity = 0,
                    }
                },
        };
    }

}