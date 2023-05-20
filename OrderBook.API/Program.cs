using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrderBook.Data.DataProvider;

var builder = WebApplication.CreateBuilder();

// Add services to the container.
builder.Services.AddScoped<IDataProvider, DataProvider>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();