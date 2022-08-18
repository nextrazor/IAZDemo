using IAZBackend.Models.ApsEntities;
using IAZBackend.FrontendData;

namespace IAZBackend
{
    public static class GanttController
    {
        /// <summary>
        /// Получение данных для диаграммы Гантта
        /// </summary>
        /// <param name="dataset">набор данных, из которого получаем данные</param>
        /// <param name="orderNo">выделяемый заказ (если null или string.Empty - выделения нет)</param>
        /// <param name="showOnlyOrderResources">
        /// true - показать только ресурсы, которые используются для выделенного заказа
        /// false - показать все ресурсы
        /// </param>
        /// <param name="showOnlyOrderManualOperation">
        /// true - показать только те ручные операции, которые относятся к выделенному заказу
        /// false - показать все ручные операции
        /// </param>
        /// <returns> Данные для диаграммы </returns>
        public static BryntumGanttData GetGanttDataForOrder(Dataset dataset, string? orderNo, bool showOnlyOrderResources, bool showOnlyOrderManualOperation)
        {
            const double EXTEND_RATIO = 1.1;        // насколько шире цикла заказа делать диаграмму Гантта

            using IAZ_ApsContext dbContext = new();
            bool highlighting = !string.IsNullOrEmpty(orderNo);
            showOnlyOrderResources &= highlighting;
            showOnlyOrderManualOperation &= highlighting;
            List<Order>? schedOrdOpers = null;
            if (highlighting)
            {
                schedOrdOpers = dbContext.Orders
                    .Where(ord => (ord.Dataset == dataset) && (ord.OrderNo == orderNo) && (ord.Resource != null))
                    .OrderBy(ord => ord.OpNo)
                    .ToList();
                if (!schedOrdOpers.Any())
                    return BryntumGanttData.Empty;
            }
            List<Models.ApsEntities.Resource> resources = showOnlyOrderResources ?
                schedOrdOpers!
                    .Select(ord => ord.Resource!)
                    .Distinct()
                    .ToList() :
                dbContext.Resources.ToList();
            BryntumGanttData ganttData = new();
            ganttData.resources.rows.AddRange(resources
                .OrderByDescending(r => r.FiniteOrInfinite)
                .ThenBy(r => r.Name)
                .Select(r => new BryntumResource()
                {
                    id = r.ResourceId,
                    name = r.Name,
                    iconCls = r.GetIcon()
                }));
            DateTime start = DateTime.MinValue;
            DateTime finish = DateTime.MaxValue;
            if (highlighting)
            {
                start = schedOrdOpers!.Min(ord => ord.StartTime)!.Value;
                finish = schedOrdOpers!.Max(ord => ord.EndTime)!.Value;
                TimeSpan delta = TimeSpan.FromDays((finish - start).TotalDays * EXTEND_RATIO / 2);
                start -= delta;
                finish += delta;
            }
            var ganttOrders = dbContext.Orders
                .Where(ord => (ord.Dataset == Dataset.CurrentDataset) && (ord.Resource != null) && (ord.StartTime < finish) && (ord.EndTime > start))
                .ToList();
            if (showOnlyOrderResources)
                ganttOrders = ganttOrders
                    .Where(ord => resources.Contains(ord.Resource!))
                    .ToList();
            if (showOnlyOrderManualOperation)
                ganttOrders = ganttOrders
                    .Where(ord => (ord.Resource!.FiniteOrInfinite == (int)ResourceType.Finite) || (ord.OrderNo == orderNo))
                    .ToList();
            ColorSelector colorSelector = new(ColorSelector.GanttColors);
            ganttData.events.rows.AddRange(ganttOrders
                .Select(ord => new BryntumEvent()
                {
                    id = ord.OrderId,
                    name = $"{ord.OpNo}. {ord.OperationName} по заказу {ord.OrderNo}",
                    startDate = ord.StartTime!.Value,
                    duration = (ord.EndTime!.Value - ord.StartTime!.Value).TotalHours,
                    iconCls = ord.GetIcon(),
                    percentDone = (int)(ord.ProgressPercent * 100),
                    eventColor = highlighting ?
                        (ord.OrderNo == orderNo ? "red" : "gray") :
                        colorSelector.GetColor(ord.OrderNo)
                }));
            int assId = 1;
            ganttData.assignments.rows.AddRange(ganttOrders
                .Select(ord => new BryntumAssignment()
                {
                    id = assId++,
                    eventId = ord.OrderId,
                    resource = ord.ResourceId!.Value
                }));
            if (highlighting)
            {
                int depId = 1;
                for (int i = 0; i < schedOrdOpers!.Count - 1; i++)
                {
                    ganttData.dependencies.rows.Add(new BryntumDependency()
                    {
                        id = depId++,
                        fromEvent = schedOrdOpers[i].OrderId,
                        toEvent = schedOrdOpers[i + 1].OrderId,
                        lag = (int)(schedOrdOpers[i + 1].StartTime!.Value - schedOrdOpers[i].EndTime!.Value).TotalSeconds
                    });
                }
            }
            return ganttData;
        }
    }
}
