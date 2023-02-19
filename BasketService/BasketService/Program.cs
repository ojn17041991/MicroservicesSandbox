using BasketService.DataAccess.Accessors;
using BasketService.DataAccess.Accessors.Abstract;
using BasketService.DataAccess.Factories;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("BasketDB");
builder.Services.AddSingleton<DbConnection>(new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IBasketAccessor, BasketAccessor>();
builder.Services.AddSingleton<IBasketItemAccessor, BasketItemAccessor>();
builder.Services.AddSingleton<IDataResponseFactory<Basket>, BasketResponseFactory>();
builder.Services.AddSingleton<IDataResponseFactory<BasketItem>, BasketItemResponseFactory>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();