using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Microsoft.EntityFrameworkCore;
using UserService.DataAccess.Accessors;
using UserService.DataAccess.Accessors.Abstract;
using UserService.DataAccess.DbContexts;
using UserService.DataAccess.Factories;
using UserService.Models;
using UserService.ServiceAccess.Accessors;
using UserService.ServiceAccess.Accessors.Abstract;
using UserService.ServiceAccess.Factories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddLogging();

builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddScoped<ISingleDataResponseFactory<User>, UserResponseFactory>();
builder.Services.AddTransient<ISingleDataResponseFactory<Basket>, BasketResponseFactory>();
builder.Services.AddTransient<IBasketServiceAccessor, BasketServiceAccessor>();

string? connectionString = builder.Configuration.GetConnectionString("UserDB");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(
        connectionString
    )
);

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