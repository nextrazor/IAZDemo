using IAZBackend.Models.ApsEntities;
using IAZBackend.FrontendData;
using Newtonsoft.Json;

namespace IAZBackend
{
    public static class GanttController
    {
        public static BryntumGanttData GetGanttDataForOrder(Dataset dataset, string orderNo)
        {
            const double EXTEND_RATIO = 1.2;        // насколько шире цикла заказа делать диаграмму Гантта

            using IAZ_ApsContext dbContext = new();
            List<Order> schedOrdOpers = dbContext.Orders
                .Where(ord => (ord.Dataset == dataset) && (ord.OrderNo == orderNo) && (ord.Resource != null))
                .OrderBy(ord => ord.OpNo)
                .ToList();
            if (!schedOrdOpers.Any())
                return BryntumGanttData.Empty;
            List<Models.ApsEntities.Resource> resources = schedOrdOpers
                .Select(ord => ord.Resource!)
                .Distinct()
                .ToList();
            BryntumGanttData ganttData = new();
            int resId = 1;
            ganttData.resources.rows.AddRange(dbContext.Resources   //resources
                .OrderByDescending(r => r.FiniteOrInfinite)
                .ThenBy(r => r.Name)
                .Select(r => new BryntumResource()
                {
                    id = r.ResourceId,
                    name = r.Name,
                    iconCls = GetResourceIcon(r)
                }));
            DateTime start = schedOrdOpers.Min(ord => ord.StartTime)!.Value;
            DateTime finish = schedOrdOpers.Max(ord => ord.EndTime)!.Value;
            TimeSpan delta = TimeSpan.FromDays((finish - start).TotalDays * EXTEND_RATIO / 2);
            start -= delta;
            finish += delta;
            var ganttOrders = dbContext.Orders
                .Where(ord => (ord.Dataset == Dataset.CurrentDataset) && (ord.Resource != null) && (ord.StartTime < finish) && (ord.EndTime > start))
                .ToList()
                .Where(ord => /*resources.Contains(ord.Resource!) &&*/ ((ord.Resource!.FiniteOrInfinite == (int)ResourceType.Finite) || (ord.OrderNo == orderNo)))
                .ToList();
            ColorSelector colorSelector = new();
            ganttData.events.rows.AddRange(ganttOrders
                .Select(ord => new BryntumEvent()
                {
                    id = ord.OrderId,
                    name = $"{ord.OpNo}. {ord.OperationName} по заказу {ord.OrderNo}",
                    startDate = ord.StartTime!.Value,
                    duration = (ord.EndTime!.Value - ord.StartTime!.Value).TotalHours,
                    iconCls = GetOperIcon(ord),
                    percentDone = (int)(ord.ProgressPercent * 100),
                    eventColor = ord.OrderNo == orderNo ? "red" : "gray" //colorSelector.GetColor(ord.OrderNo)
                }));
            int assId = 1;
            ganttData.assignments.rows.AddRange(ganttOrders
                .Select(ord => new BryntumAssignment()
                {
                    id = assId++,
                    eventId = ord.OrderId,
                    resource = ord.ResourceId.Value
                }));
            int depId = 1;
            for (int i = 0; i < schedOrdOpers.Count - 1; i++)
            {
                ganttData.dependencies.rows.Add(new BryntumDependency()
                {
                    id = depId++,
                    fromEvent = schedOrdOpers[i].OrderId,
                    toEvent = schedOrdOpers[i + 1].OrderId,
                    lag = (int)(schedOrdOpers[i + 1].StartTime.Value - schedOrdOpers[i].EndTime.Value).TotalSeconds
                });
            }
            return ganttData;
        }

        private static string GetResourceIcon(Models.ApsEntities.Resource r)
        {
            return r.FiniteOrInfinite == (int)ResourceType.Finite ?
                "b-fa b-fa-tachograph-digital" :
                "b-fa b-fa-hands";
        }

        private static string GetOperIcon(Order ord)
        {
            string name = ord.OperationName.ToLower();
            if (name.Contains("чпу")) return "b-fa b-fa-tachograph-digital";
            if (name.Contains("виброудар")) return "b-fa b-fa-arrows-to-dot";
            if (name.Contains("дробе")) return "b-fa b-fa-arrows-to-dot";
            if (name.Contains("гибк")) return "b-fa b-fa-bezier-curve";
            if (name.Contains("контрол")) return "b-fa b-fa-clipboard";
            if (name.Contains("консерв")) return "b-fa b-fa-can-food";
            if (name.Contains("маркир")) return "b-fa b-fa-stamp";
            if (name.Contains("пломб")) return "b-fa b-fa-award";
            if (name.Contains("подготов")) return "b-fa b-fa-hand-holding-box";
            if (name.Contains("правка")) return "b-fa b-fa-screwdriver-wrench";
            if (name.Contains("протир")) return "b-fa b-fa-broom";
            if (name.Contains("размет")) return "b-fa b-fa-highlighter-line";
            if (name.Contains("раскрой")) return "b-fa b-fa-scissors";
            if (name.Contains("сверлил")) return "b-fa b-fa-bore-hole";
            if (name.Contains("слесарн")) return "b-fa b-fa-fan";//"b-fa b-fa-hammer- crash";
            if (name.Contains("транспортир")) return "b-fa b-fa-truck";//"b-fa b-fa-cart-flatbed-boxes";
            if (name.Contains("упаков")) return "b-fa b-fa-box";
            if (name.Contains("установ")) return "b-fa b-fa-arrow-down-to-line";
            if (name.Contains("фрезер")) return "b-fa b-fa-fan";
            return "b-fa b-fa-face-head-bandage";
        }
    }

    class ColorSelector
    {
        string[] colors = new string[]
        {
//            "red",
            "pink",
            "purple",
            "violet",
            "indigo",
            "blue",
            "cyan",
            "teal",
            "green",
            "lime",
            "yellow",
            "orange",
            "deep-orange",
            "gray",
            "gantt-green"
        };

        Dictionary<string, int> tagColors = new Dictionary<string, int>();
        Random rnd = new();

        public string GetColor(string tag)
        {
            if (!tagColors.ContainsKey(tag))
            {
                int tagIndex = rnd.Next(colors.Length);
                tagColors.Add(tag, tagIndex);
            }
            return colors[tagColors[tag]];
        }
    }
}
