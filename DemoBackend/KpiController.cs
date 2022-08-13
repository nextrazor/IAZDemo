using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class KpiController
    {
        public static DateTime GetEarliestStart()
        {
            using var dbContext = new IAZ_ApsContext();
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            var schedOrders = dbContext.Orders
                .Where(ord => (ord.DatasetId == scheduleDsId) && ord.StartTime.HasValue);
            if (!schedOrders.Any())
                return DateTime.Now;
            return schedOrders.Min(ord => ord.StartTime!.Value);
        }

        public static NamedValue[] GetLateOrders()
        {
            using var dbContext = new IAZ_ApsContext();
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            IEnumerable<Order> lastOpers = dbContext.Orders
                .Where(ord => ord.DatasetId == scheduleDsId)
                .GroupBy(ord => ord.OrderNo)
                .Select(og => og.OrderByDescending(op => op.OpNo).First());
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
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
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
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            IEnumerable<Order> orders = dbContext.Orders
                .Where(ord => (ord.DatasetId == scheduleDsId) && (ord.AssignedResource != null) && (ord.AssignedResource.FiniteOrInfinite == (int)ResourceType.Finite) &&
                    (ord.StartTime!.Value < endTime) && (ord.EndTime!.Value > startTime));
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
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            IEnumerable<IGrouping<Resource, Order>> orderGroups = (IEnumerable<IGrouping<Resource, Order>>)dbContext.Orders
                .Where(ord => (ord.DatasetId == scheduleDsId) && (ord.AssignedResource != null) && (ord.AssignedResource.FiniteOrInfinite == (int)ResourceType.Finite) &&
                    (ord.StartTime!.Value < endTime) && (ord.EndTime!.Value > startTime))
                .GroupBy(ord => ord.AssignedResource);
            LoadingValue[] result = new LoadingValue[orderGroups.Count() * 2];
            int i = 0;
            foreach (var group in orderGroups)
            {
                double machineLoading = group
                    .Sum(ord => ((ord.EndTime!.Value > endTime ? endTime : ord.EndTime!.Value) - (ord.StartTime!.Value < startTime ? startTime : ord.StartTime!.Value)).TotalDays);
                if (machineLoading > totalTime)
                    throw new ApplicationException($"Расчетное значение OEE для ресурса {group.Key} составило больше 100%");
                string machineName = group.Key.ToString() ?? throw new NullReferenceException();
                result[i] = new LoadingValue(machineName, "Работа", machineLoading);
                result[i + 1] = new LoadingValue(machineName, "Простой", totalTime - machineLoading);
                i += 2;
            }
            return result;
        }
    }
}
