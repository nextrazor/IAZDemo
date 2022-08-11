using DemoBackend.Models;
using IAZBackend;
using IAZBackend.Config;
using IAZBackend.Models.ApsEntities;
using Microsoft.Net.Http.Headers;
using System.Reflection;

//Configuration
var config = new ConfigLoader();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{   
    options.AddDefaultPolicy(policy => { policy.WithOrigins(config.AllowedURL).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); });
    options.AddPolicy(name: config.PolicyName, policy => { policy.WithOrigins(config.AllowedURL).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); });
});

// App
var app = builder.Build();
app.UseCors(config.PolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/workers", () =>   
{
    using (IAZ_PBDContext dbContext = new IAZ_PBDContext())
    {
        var workers = dbContext.WorkersDemoData.ToArray();

        return workers;
    }
})
.WithName("GetWorkers");

app.MapGet("/additionalGroups", () =>
{
    using (IAZ_PBDContext dbContext = new IAZ_PBDContext())
    {
        var workers = dbContext.AdditionalGroups.ToArray();

        return workers;
    }
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