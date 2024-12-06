using ErrorHandling.API.ExceptionHandler;
using ErrorHandling.API.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<DatabaseExceptionHandler>().AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();



app.UseExceptionHandler(app => { });



//app.UseExceptionHandler(x =>
//{
//    x.Run(x =>
//    {
//        var exception = x.Features.Get<IExceptionHandlerFeature>()!.Error;


//        if (exception is DivideByZeroException)
//        {
//            x.Response.StatusCode = 400;
//            x.Response.ContentType = "application/json";
//            return x.Response.WriteAsync("Bir say? s?f?ra bölünemez");
//        }

//        if (exception is ProductNotFoundException)
//        {
//            x.Response.StatusCode = 400;
//            x.Response.ContentType = "application/json";

          

//            var problemDetails= new ProblemDetails
//            {
//                Title = "Product not found",
//                Detail = exception.Message,
//                Status = 404
//            };


//            return x.Response.WriteAsJsonAsync(problemDetails);
//        }

//        x.Response.StatusCode = 500;
//        x.Response.ContentType = "application/json";


//        // logger.logError("");


//        return x.Response.WriteAsync("Bir hata olu?tu");
//    });
//});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();