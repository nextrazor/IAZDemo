﻿using DemoBackend.Models;
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
    /* Тестовые данные для панели KPI
    var lateOrders = new NamedValue[] { new NamedValue("В срок", 0.8), new NamedValue("Со срывом срока", 0.12), new NamedValue("Не спланированы", 0.08) };
    var lateOpers = new NamedValue[] { new NamedValue("В срок", 0.9), new NamedValue("Со срывом срока", 0.06), new NamedValue("Не спланированы", 0.04) };
    var machNames = new string[]
    {
        "1696_Центр фрезерный обрабатывающий с ЧПУ",
        "2157_Центр фрезерный обрабатывающий с ЧПУ",
        "2086_Центр фрезерный обрабатывающий с ЧПУ",
        "2197_Центр фрезерный обрабатывающий с ЧПУ"
    };
    var loadingData = new LoadingValue[]
    {
        new LoadingValue(machNames[0], "Работа", 0.3), new LoadingValue(machNames[0], "Простой", 0.7),new LoadingValue(machNames[0], "Перерыв", 0),
        new LoadingValue(machNames[1], "Работа", 0.45), new LoadingValue(machNames[1], "Простой", 0.5),new LoadingValue(machNames[1], "Перерыв", 0.05),
        new LoadingValue(machNames[2], "Работа", 0), new LoadingValue(machNames[2], "Простой", 0.8),new LoadingValue(machNames[2], "Перерыв", 0.2),
        new LoadingValue(machNames[3], "Работа", 0.5), new LoadingValue(machNames[3], "Простой", 0.4),new LoadingValue(machNames[3], "Перерыв", 0.1)
    };
    var ppData = new PainPoint[]
    {
        new PainPoint("8518497D-E6CC-4E81-98BF-0734AAD7CFE2", new string[] { "Оборудование", PainPointSeverity.Low.ToString() }, PainPointSeverity.Low, $"{machNames[0]} простаивает больше 3 дней с 12.08.2022"),
        new PainPoint("8518497D-E6CC-4E81-98BF-0734AAD7CDE2", new string[] { "Оборудование", PainPointSeverity.Low.ToString() }, PainPointSeverity.Low, $"{machNames[2]} простаивает больше 6 дней с 19.08.2022"),
        new PainPoint("8518497D-E6CC-4E81-98BF-0734AAD7CCE2", new string[] { "Заказ", PainPointSeverity.Low.ToString() }, PainPointSeverity.Low, "НЗП по заказу M14003941 пролеживает больше 6 дней с 12.08.2022 между операциями 60 и 65"),
        new PainPoint("8518497D-E6CC-4E81-98BF-0734AAD7CAE2", new string[] { "Заказ", PainPointSeverity.Normal.ToString() }, PainPointSeverity.Normal, $"Заказ 1020_394_Э10.3115.0031.900 просрочен на 12 дней")
    };
    KpiPageData kpiData = new KpiPageData(lateOrders, lateOpers, 0.52, loadingData, ppData); */

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
    return DemandController.GetDemands(Dataset.CurrentDataset);
})
.WithName("GetDemands");

app.MapGet("/ordergantt/{orderNo}", (string orderNo) =>
{
    return GanttController.GetGanttDataForOrder(Dataset.CurrentDataset, orderNo).Result();
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