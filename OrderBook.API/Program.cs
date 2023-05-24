using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderBook.API.Services.DataProvider;
using System;

var builder = WebApplication.CreateBuilder();

// Add services to the container.
builder.Services.AddScoped<IDataProvider, DataProvider>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var dataProvider = scope.ServiceProvider.GetRequiredService<IDataProvider>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();