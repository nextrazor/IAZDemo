using DemoBackend.Models;
using IAZBackend;
using IAZBackend.Config;
using IAZBackend.Models.ApsEntities;
using Microsoft.Net.Http.Headers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var config = new ConfigLoader();

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
            AllowAnyMethod().AllowCredentials();

        });

    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
        {
            policy.WithOrigins("http://localhost:8000").
                              AllowAnyHeader().
                              AllowAnyMethod().AllowCredentials();
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

    foreach (IGanttElement apsTask in GetApsTasks("Schedule"))
        data.Add(apsTask);

    data.Add(GetApsResources());

    return data.Result();
})
.WithName("GetGanttData");

IEnumerable<IGanttElement> GetApsTasks(string datasetName)
{
    using (IAZ_ApsContext dbContext = new IAZ_ApsContext())
    {
        Dataset dataset = dbContext.Orders_Dataset.FirstOrDefault(ds => ds.Name == datasetName) ??
            throw new ApplicationException($"Dataset '{datasetName}' not found");
        return dbContext.Orders
            .Where(ord => (ord.Dataset == dataset) && (ord.StartTime.HasValue) && (ord.EndTime.HasValue))
            .Select(ord => new IAZBackend.Task(ord.StartTime.Value, ord.EndTime.Value, ord.ToString(), ord.OrdersId, ord.Resource, "Project",
                new string[] {}, Convert.ToInt32(ord.MidBatchQuantity * 100 / ord.Quantity), false))
            .ToArray();
    }
}

IAZBackend.Resource[] GetApsResources()
{
    using (IAZ_ApsContext dbContext = new IAZ_ApsContext())
    {
        return dbContext.Resources.Select(el => new IAZBackend.Resource(el.ResourcesId, el.Name)).ToArray();
    }
}

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}