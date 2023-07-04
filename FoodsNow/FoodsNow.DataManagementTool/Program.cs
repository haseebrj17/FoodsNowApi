using FoodsNow.DbEntities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<FoodsNowDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("FoodsNowDb")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
