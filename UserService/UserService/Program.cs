using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Npgsql;
using System.Data.Common;
using UserService.DataAccess.Accessors;
using UserService.DataAccess.Accessors.Abstract;
using UserService.DataAccess.Factories;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("UserDB");
builder.Services.AddSingleton<DbConnection>(new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IUserAccessor, UserAccessor>();
builder.Services.AddSingleton<IDataResponseFactory<User>, UserResponseFactory>();

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