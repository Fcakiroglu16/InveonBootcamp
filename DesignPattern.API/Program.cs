using DesignPattern.API.HasAIsA;
using DesignPattern.API.Models;
using DesignPattern.API.Models.Decarators;
using DesignPattern.API.Models.Decorators;
using DesignPattern.API.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IImageProcess, ImageProcess>();


builder.Services.AddScoped<IProductRepository, ProductRepositoryWithSqlServer>();


builder.Services.AddScoped<IProductRepository>(sp =>
{
    Dictionary<string, Func<IProductRepository>> CommanTypeDbOperationDictionary =
        new Dictionary<string, Func<IProductRepository>>();


    CommanTypeDbOperationDictionary.Add("A", () => new ProductRepositoryWithSqlServer());
    CommanTypeDbOperationDictionary.Add("B", () => new ProductRepositoryWithSqlOracle());
    CommanTypeDbOperationDictionary.Add("C", () => new ProductRepositoryWithSqlOracle());
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

    if (httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("companyType", out var comanyType))
    {
        return CommanTypeDbOperationDictionary[comanyType!]();
    }

    return CommanTypeDbOperationDictionary["A"]();
    // throw new Exception("Company Type is not defined");
});


builder.Services.AddScoped<IProductService>(sp =>
{
    // IProductService=> LoggingDecorator
    // IProductService => ProdcutService

    Dictionary<string, Func<IProductService>> serviceDictionary =
        new Dictionary<string, Func<IProductService>>();


    var productRepository = sp.GetRequiredService<IProductRepository>();
    var memoryCache = sp.GetRequiredService<IMemoryCache>();
    var imageProcess = sp.GetRequiredService<IImageProcess>();
    var logger = sp.GetRequiredService<ILogger<ProductService>>();

    var loggerDecorator = sp.GetRequiredService<ILogger<LoggingDecorator>>();


    var cachingDecorator =
        new CachingDecorator(new ProductService(productRepository, imageProcess, logger, memoryCache), memoryCache);

    var loggingDecorator =
        new LoggingDecorator(new ProductService(productRepository, imageProcess, logger, memoryCache), loggerDecorator);


    var cachingAndLogging = new LoggingDecorator(cachingDecorator, loggerDecorator);


    serviceDictionary.Add("A", () => loggingDecorator);
    serviceDictionary.Add("B", () => cachingDecorator);
    serviceDictionary.Add("C", () => cachingAndLogging);

    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    if (httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("companyType", out var comanyType))
    {
        return serviceDictionary[comanyType!]();
    }

    throw new Exception("Company Type is not defined");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


var client = new Client();


app.Run();