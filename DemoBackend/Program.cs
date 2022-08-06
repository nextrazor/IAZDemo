using DemoBackend.Models;
using IAZBackend;
using Microsoft.Net.Http.Headers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:8000").
            AllowAnyHeader().
            AllowAnyMethod();

        });

    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
        {
            policy.WithOrigins("http://localhost:8000").
                              AllowAnyHeader().
                              AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

var context = new IAZ_PBDContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/workers", () =>   
{
    var workers = context.WorkersDemoData.ToArray();

    return workers;
})
.WithName("GetWorkers");

app.MapGet("/additionalGroups", () =>
{
    var workers = context.AdditionalGroups.ToArray();

    return workers;
})
.WithName("GetAdditionalGroups");

app.MapGet("/ganttData", () =>
{
    GanttData data = new GanttData();

    data.Add(new IAZBackend.Project(
            DateTime.Now,
            DateTime.Now.AddDays(3),
            "Project 1",
            "P1",
            30
        ));

    data.Add(new IAZBackend.Task(
            DateTime.Now,
            DateTime.Now.AddDays(1),
            "Task 1",
            "T1",
            "P1",
            new string[] { },
            10,
            false
        ));

    data.Add(new IAZBackend.Task(
            DateTime.Now.AddDays(1),
            DateTime.Now.AddDays(2),
            "Task 1",
            "T2",
            "P1",
            new string[] { "T1"},
            10,
            false
        ));

    data.Add(new IAZBackend.Milestone(
            DateTime.Now.AddDays(2),
            DateTime.Now.AddDays(3),
            "Milestone 1",
            "M1",
            "P1",
            new string[] { "T2" },
            40,
            true
        ));

    return data.Result();
})
.WithName("GetGanttData");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}