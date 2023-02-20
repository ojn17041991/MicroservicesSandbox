using ItemService.DataAccess.Accessors;
using ItemService.DataAccess.Accessors.Abstract;
using ItemService.DataAccess.Factories;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("ItemDB");
builder.Services.AddSingleton<DbConnection>(new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IItemAccessor, ItemAccessor>();
builder.Services.AddSingleton<IDataResponseFactory<Item>, ItemResponseFactory>();

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