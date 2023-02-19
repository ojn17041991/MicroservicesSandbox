using BasketService.DataAccess;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("BasketDB");
builder.Services.AddSingleton<DbConnection>(new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IDataAccessor<Basket>, BasketAccessor>();
builder.Services.AddSingleton<IDataResponseFactory<Basket>, BasketResponseFactory>();

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