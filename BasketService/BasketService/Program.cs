using BasketService.DataAccess.Accessors;
using BasketService.DataAccess.Accessors.Abstract;
using BasketService.DataAccess.Factories;
using BasketService.Model;
using BasketService.ServiceAccess.Accessors;
using BasketService.ServiceAccess.Accessors.Abstract;
using BasketService.ServiceAccess.Factories;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Postgres;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddLogging();

string connectionString = builder.Configuration.GetConnectionString("BasketDB");
builder.Services.AddTransient<DbConnectionFactory, NpgSqlConnectionFactory>(t => {
    return new NpgSqlConnectionFactory(connectionString);
});
builder.Services.AddSingleton<IBasketAccessor, BasketAccessor>();
builder.Services.AddSingleton<IBasketItemAccessor, BasketItemAccessor>();
builder.Services.AddSingleton<ISingleDataResponseFactory<Basket>, BasketResponseFactory>();
builder.Services.AddSingleton<IDataResponseFactory<BasketItem>, BasketItemResponseFactory>();
builder.Services.AddSingleton<ISingleDataResponseFactory<Item>, ItemResponseFactory>();
builder.Services.AddSingleton<IItemServiceAccessor, ItemServiceAccessor>();

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