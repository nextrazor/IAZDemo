

using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class GanttController
    {
        public static GanttData GetGanttDataForOrder(Dataset dataset, string orderNo)
        {
            const double EXTEND_RATIO = 1.2;        // насколько шире цикла заказа делать диаграмму Гантта

            using IAZ_ApsContext dbContext = new();
            List<Order> schedOrdOpers = dbContext.Orders
                .Where(ord => (ord.Dataset == dataset) && (ord.OrderNo == orderNo) && (ord.Resource != null))
                .ToList();
            if (!schedOrdOpers.Any())
                return GanttData.Empty;
            List<Models.ApsEntities.Resource> resources = schedOrdOpers
                .Select(ord => ord.Resource!)
                .Distinct()
                .ToList();
            GanttData ganttData = new();
            ganttData.Add(resources
                .Select(r => new Resource(r.ResourceId, r.Name))
                .ToArray());
            DateTime start = schedOrdOpers.Min(ord => ord.StartTime)!.Value;
            DateTime finish = schedOrdOpers.Max(ord => ord.EndTime)!.Value;
            TimeSpan delta = TimeSpan.FromDays((finish - start).TotalDays * EXTEND_RATIO / 2);
            start -= delta;
            finish += delta;
            foreach (Order order in dbContext.Orders
                .Where(ord => (ord.Dataset == Dataset.CurrentDataset) && (ord.Resource != null) && (ord.StartTime < finish) && (ord.EndTime > start))
                .ToList()
                .Where(ord => resources.Contains(ord.Resource!) && ((ord.Resource!.FiniteOrInfinite == (int)ResourceType.Finite) || (ord.OrderNo == orderNo))))
            {
                ganttData.Add(new Task(order.StartTime!.Value, order.EndTime!.Value, order.ToString(), order.OrderId, order.ResourceId!.Value,
                    order.OrderNo, Array.Empty<string>(), (int)order.MidBatchQuantity, false, GetHighlightType(order, orderNo)));
            }
            return ganttData;
        }

        static HighlightType GetHighlightType(Order order, string orderNo)
        {
            bool isLate = order.EndTime.HasValue && order.DueDate.HasValue && (order.EndTime.Value > order.DueDate.Value);
            return order.OrderNo == orderNo ?
                (isLate ? HighlightType.LateHighlighted : HighlightType.Highlighted) :
                (isLate ? HighlightType.Late : HighlightType.Normal);
        }
    }
}
