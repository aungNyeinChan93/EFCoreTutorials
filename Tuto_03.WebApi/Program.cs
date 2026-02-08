using Microsoft.AspNetCore.Mvc;
using Tuto_03.WebApi.Tests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

// Test

app.MapGet("/test/one", () =>
{
    var testOne = new TestOne();
    testOne.WhoAmI();
    return new { name = "House Maid!"};
});

app.MapGet("/tests/{id}", async ([FromRoute] int? id,HttpContext context) =>
{
    string pathName = context.Request.Path;
    var result =  $"Test {id} and {pathName}";
    await context.Response.WriteAsJsonAsync(result);
});



app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
