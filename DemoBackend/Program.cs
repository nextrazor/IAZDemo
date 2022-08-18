using DemoBackend.Models;
using IAZBackend;
using IAZBackend.Config;
using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
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

app.MapGet("/testData", () =>
{
    KpiPageData kpiData = new KpiPageData(
        KpiController.GetLateOrders(),
        KpiController.GetLateOpers(),
        KpiController.GetMonthOee(KpiController.GetEarliestStart()),
        KpiController.GetLoadingData(KpiController.GetEarliestStart()),
        KpiController.GetPainPoints());

    return kpiData.GetJson();
})
.WithName("GetTestData");

app.MapGet("/demands", () =>
{
    return $"{{\"data\":{JsonConvert.SerializeObject(DemandController.GetDemands(Dataset.CurrentDataset))}}}";
})
.WithName("GetDemands");

app.MapGet("/ordergantt/{orderNo:maxlength(99)}/{showOnlyOrderResources:bool=true}/{showOnlyOrderManualOperation:bool=true}",
    (string? orderNo, bool showOnlyOrderResources, bool showOnlyOrderManualOperation) =>
{
    if (orderNo == "undefined")
        orderNo = null;
    BryntumGanttData ganttData = GanttController.GetGanttDataForOrder(Dataset.CurrentDataset, orderNo, showOnlyOrderResources, showOnlyOrderManualOperation);
    return JsonConvert.SerializeObject(ganttData);
})
.WithName("GetOrderGantt");

app.MapGet("/workers", () =>   
{
    using (IAZ_PBDContext dbContext = new IAZ_PBDContext())
    {
        var workers = dbContext.WorkersDemoData.ToArray();

        return workers;
    }
})
.WithName("GetWorkers");

app.MapGet("/calendar/{tabNumber:required=014523}/{date:datetime:required=2022-07-01}", (string tabNumber, DateTime date) =>       // 014523 018564
{
    return JsonConvert.SerializeObject(CalendarController.GetWorkerTasks(Dataset.CurrentDataset, tabNumber, date, date.AddDays(7)));
})
.WithName("GetCalendar");

app.MapGet("/kanban/{groupNumber:int:max(100):required=1}/{date:datetime:required=2022-07-01}", (int groupNumber, DateTime date) =>
{
    return JsonConvert.SerializeObject(MasterKanbanController.GetKanbanTasks(Dataset.CurrentDataset, groupNumber, date));
})
.WithName("GetKanban");

app.MapGet("/kanbanColumns/{groupNumber:int:max(100):required=1}", (int groupNumber) =>
{
    return "{ \"data\":{ \"columns\":" + JsonConvert.SerializeObject(MasterKanbanController.GetKanbanColumns(groupNumber)) + "}}";
})
.WithName("GetKanbanColumns");

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
            .Where(ord => (ord.Dataset == dataset) && (ord.StartTime.HasValue) && (ord.EndTime.HasValue) && (ord.Resource != null))
            .Select(ord => new IAZBackend.Task(ord.StartTime!.Value, ord.EndTime!.Value, ord.ToString(), ord.OrderId, ord.ResourceId!.Value, "Project",
                new string[] {}, Convert.ToInt32(ord.MidBatchQuantity * 100 / ord.Quantity), false, HighlightType.Normal))
            .ToArray();
    }
}

IAZBackend.Resource[] GetApsResources()
{
    using (IAZ_ApsContext dbContext = new IAZ_ApsContext())
    {
        return dbContext.Resources.Select(el => new IAZBackend.Resource(el.ResourceId, el.Name)).ToArray();
    }
}

app.Run();