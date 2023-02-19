using CentralService.DataProviders;
using CentralService.DataProviders.Abstract;
using CentralService.Models.Baskets;
using CentralService.Models.Responses;
using CentralService.Models.Responses.Abstract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IHttpDataResponseFactory, HttpDataResponseFactory>();
builder.Services.AddTransient<IHttpDataProvider<Basket?>, BasketProvider>();
builder.Services.AddHttpClient("basketService", configuration =>
    configuration.BaseAddress = new Uri("https://localhost:7101/")
);
builder.Services.AddLogging();

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