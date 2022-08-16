using IAZBackend.Models.ApsEntities;
using IAZBackend.FrontendData;

namespace IAZBackend
{
    public class DemandController
    {
        public static Demand[] GetDemands(Dataset dataset)
        {
            using var dbContext = new IAZ_ApsContext();
            int scheduleDsId = dbContext.Orders_Dataset
                .FirstOrDefault(ds => ds.Name == "Schedule")?.DatasetId
                ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
            var lastOpers = dbContext.Orders
                .Where(ord => ord.DatasetId == scheduleDsId)
                .GroupBy(ord => ord.OrderNo)
                .Select(og => og.OrderByDescending(op => op.OpNo).First())
                .AsEnumerable();
            return lastOpers
                .OrderBy(lo => lo.DueDate)
                .ThenBy(lo => lo.OrderNo)
                .Select(lo => new Demand()
                {
                    orderNo = lo.OrderNo,
                    dueDate = lo.DueDate,
                    endTime = lo.EndTime,
                    partNo = lo.PartNo,
                    quantity = lo.Quantity,
                    isMilitary = lo.IsMilitary,
                    workGroup = lo.WorkGroup,
                    percent = GetManufPercent(lo),
                    orderStatus = GetOrderStatus(lo),
                    dateStatus = GetDateStatus(lo)
                })
                .ToArray();
        }

        static double GetManufPercent(Order oper)
        {
            using IAZ_ApsContext dbContext = new();
            var orderOpers = dbContext.Orders
                .Where(op => (op.Dataset == oper.Dataset) && (op.OrderNo == oper.OrderNo))
                .AsEnumerable();
            double fullLabour = orderOpers.Sum(op => op.FullLabour);
            double producedLabour = orderOpers.Sum(op => op.ProducedLabour);
            if (fullLabour <= 0)
                return 0;
            if (fullLabour >= producedLabour)
                return 1;
            return producedLabour / fullLabour;
        }

        static string GetOrderStatus(Order lastOper)
        {
            if (lastOper.MidBatchQuantity >= lastOper.Quantity)
                return "success";
            if (lastOper.Resource == null)
                return "exception";
            using IAZ_ApsContext dbContext = new();
            if (dbContext.Orders.Any(op => (op.Dataset == lastOper.Dataset) && (op.OrderNo == lastOper.OrderNo) && (op.MidBatchQuantity > 0)))
                return "active";
            return "normal";
        }

        static string GetDateStatus(Order lastOper)
        {
            if (!lastOper.EndTime.HasValue)
                return "not scheduled";
            if (!lastOper.DueDate.HasValue)
                return "normal";
            if (lastOper.EndTime.Value > lastOper.DueDate)
                return "late";
            DateTime riskBound = lastOper.DueDate.Value.AddDays(-7);
            if (lastOper.EndTime > riskBound)
                return "at risk";
            return "normal";
        }
    }
}
