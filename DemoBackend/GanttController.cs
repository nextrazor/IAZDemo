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
                    iconCls = GetResourceIcon(r)
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
                    iconCls = GetOperIcon(ord),
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
            if (name.Contains("слесарн")) return "b-fa b-fa-fan";
            if (name.Contains("транспортир")) return "b-fa b-fa-truck";
            if (name.Contains("упаков")) return "b-fa b-fa-box";
            if (name.Contains("установ")) return "b-fa b-fa-arrow-down-to-line";
            if (name.Contains("фрезер")) return "b-fa b-fa-fan";
            return "b-fa b-fa-face-head-bandage";
        }
    }

    class ColorSelector
    {
        public static string[] GanttColors = new string[]
        {
//            "red",        // используется для подсветки заказа и не выбирается автоматически
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
        public static string[] KanbanColors = new string[]
        {
            "red",
            "pink",
            "purple",
            "deep-purple",
            "indigo",
            "blue",
            "light-blue",
            "cyan",
            "teal",
            "green",
            "light-green",
            "lime",
            "yellow",
            "amber",
            "orange",
            "deep-orang"
        };

        string[] availableColors;

        public ColorSelector(string[] colors) => availableColors = colors;

        static Dictionary<string, int> tagColors = new Dictionary<string, int>();
        Random rnd = new();

        public string GetColor(string tag)
        {
            if (!tagColors.ContainsKey(tag))
            {
                int tagIndex = rnd.Next(availableColors.Length);
                tagColors.Add(tag, tagIndex);
            }
            return availableColors[tagColors[tag]];
        }
    }
}
