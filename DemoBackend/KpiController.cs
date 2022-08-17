using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class KpiController
    {
        public static DateTime GetEarliestStart()
        {
            using var dbContext = new IAZ_ApsContext();
            var schedOrders = dbContext.Orders
                .Where(ord => (ord.DatasetId == Dataset.CurrentDataset.DatasetId) && ord.StartTime.HasValue);
            if (!schedOrders.Any())
                return DateTime.Now;
            return schedOrders.Min(ord => ord.StartTime!.Value);
        }

        public static NamedValue[] GetLateOrders()
        {
            using var dbContext = new IAZ_ApsContext();
            var lastOpers = dbContext.Orders
                .Where(ord => ord.DatasetId == Dataset.CurrentDataset.DatasetId)
                .GroupBy(ord => ord.OrderNo)
                .Select(og => og.OrderByDescending(op => op.OpNo).First())
                .AsEnumerable();
            int goodOrders = lastOpers
                .Where(op => op.EndTime.HasValue && (!op.DueDate.HasValue || (op.EndTime!.Value <= op.DueDate!.Value)))
                .Count();
            int lateOrders = lastOpers
                .Where(op => op.EndTime.HasValue && op.DueDate.HasValue && (op.EndTime!.Value > op.DueDate!.Value))
                .Count();
            int notSchedOrders = lastOpers
                .Where(op => !op.EndTime.HasValue)
                .Count();
            return new NamedValue[] { new NamedValue("В срок", goodOrders), new NamedValue("Со срывом срока", lateOrders), new NamedValue("Не спланированы", notSchedOrders) };
        }

        public static NamedValue[] GetLateOpers()
        {
            using var dbContext = new IAZ_ApsContext();
            int scheduleDsId = Dataset.CurrentDataset.DatasetId;
            int goodOpers = dbContext.Orders
                .Where(op => (op.DatasetId == scheduleDsId) && op.EndTime.HasValue && (!op.DueDate.HasValue || (op.EndTime!.Value <= op.DueDate!.Value)))
                .Count();
            int lateOpers = dbContext.Orders
                .Where(op => (op.DatasetId == scheduleDsId) && op.EndTime.HasValue && op.DueDate.HasValue && (op.EndTime!.Value > op.DueDate!.Value))
                .Count();
            int notSchedOpers = dbContext.Orders
                .Where(op => (op.DatasetId == scheduleDsId) && !op.EndTime.HasValue)
                .Count();
            return new NamedValue[] { new NamedValue("В срок", goodOpers), new NamedValue("Со срывом срока", lateOpers), new NamedValue("Не спланированы", notSchedOpers) };
        }

        public static double GetMonthOee(DateTime startTime)
        {
            using var dbContext = new IAZ_ApsContext();
            DateTime endTime = startTime.AddMonths(1);
            var orders = dbContext.Orders
                .Where(ord => (ord.DatasetId == Dataset.CurrentDataset.DatasetId) && (ord.Resource != null) && (ord.Resource.FiniteOrInfinite == (int)ResourceType.Finite) &&
                    (ord.StartTime!.Value < endTime) && (ord.EndTime!.Value > startTime))
                .AsEnumerable();
            if (!orders.Any())
                return 0;
            int resCount = orders.Select(ord => ord.Resource).Distinct().Count();
            double totalTime = resCount * (endTime - startTime).TotalDays;
            double sumLoading = orders
                .Sum(ord => ((ord.EndTime!.Value > endTime ? endTime : ord.EndTime!.Value) - (ord.StartTime!.Value < startTime ? startTime : ord.StartTime!.Value)).TotalDays);
            if (sumLoading > totalTime)
                throw new ApplicationException("Расчетное значение OEE составило больше 100%");
            return sumLoading / totalTime;
        }

        public static LoadingValue[] GetLoadingData(DateTime startTime)
        {
            using var dbContext = new IAZ_ApsContext();
            DateTime endTime = startTime.AddMonths(1);
            double totalTime = (endTime - startTime).TotalDays;
            var orderGroups = dbContext.Orders
                .Where(ord => (ord.DatasetId == Dataset.CurrentDataset.DatasetId) && (ord.Resource != null) && (ord.Resource.FiniteOrInfinite == (int)ResourceType.Finite) &&
                    (ord.StartTime!.Value < endTime) && (ord.EndTime!.Value > startTime))
                .AsEnumerable()
                .GroupBy(ord => ord.Resource)
                .ToArray();
            List<LoadingValue> loadingValues = new List<LoadingValue>();
            foreach (var group in orderGroups.OrderBy(gr => gr.Key!.ShortName))
            {
                double machineLoading = group
                    .Sum(ord => ((ord.EndTime!.Value > endTime ? endTime : ord.EndTime!.Value) - (ord.StartTime!.Value < startTime ? startTime : ord.StartTime!.Value)).TotalDays);
                if (machineLoading > totalTime)
                    throw new ApplicationException($"Расчетное значение OEE для ресурса {group.Key} составило больше 100%");
                string machineName = group.Key?.ShortName ?? throw new NullReferenceException("В статистику попали данные без привязки к ресурсу");
                loadingValues.Add(new LoadingValue(machineName, "Работа", machineLoading));
                loadingValues.Add(new LoadingValue(machineName, "Простой", totalTime - machineLoading));
            }
            return loadingValues.Where(lv => lv.value > 0).ToArray();
        }

        public static PainPoint[] GetPainPoints()
        {
            using var dbContext = new IAZ_ApsContext();
            Dataset scheduleDs = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            return new PainPointCollector().GetAllPainPoints(scheduleDs);
        }
    }
}
