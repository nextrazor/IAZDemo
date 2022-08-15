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
                .Select(lo => new Demand()
                {
                    orderNo = lo.OrderNo,
                    dueDate = lo.DueDate,
                    endTime = lo.EndTime,
                    partNo = lo.PartNo,
                    quantity = lo.Quantity,
                    isMilitary = lo.IsMilitary,
                    workGroup = lo.WorkGroup
                })
                .ToArray();
        }
    }
}
