using ItemService.DataAccess.Accessors;
using ItemService.DataAccess.Accessors.Abstract;
using ItemService.DataAccess.Factories;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Postgres;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("ItemDB");
builder.Services.AddTransient<DbConnectionFactory, NpgSqlConnectionFactory>(t => {
    return new NpgSqlConnectionFactory(connectionString);
});
builder.Services.AddSingleton<IItemAccessor, ItemAccessor>();
builder.Services.AddSingleton<ISingleDataResponseFactory<Item>, ItemResponseFactory>();

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