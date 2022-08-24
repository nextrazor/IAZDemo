using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class CalendarController
    {
        public static CalendarTaskData GetWorkerTasks(Dataset currentDataset, string workerCode, DateTime start, DateTime finish)
        {
            using IAZ_ApsContext dbContext = new();
            CalendarTaskData data = new();
            SecConstraint? worker = dbContext.SecConstraints
                .FirstOrDefault(sc => sc.Name.StartsWith(workerCode));
            if (worker == null)
                return data;
            int oscdId = 1;
            var orders = worker
                .OrderSecConstraints
                .Where(osc => (osc.ConstraintUsage == (int)ConstraintUsage.IncrementForProcessTime) ||
                    ((osc.ConstraintUsage == (int)ConstraintUsage.Cnc) &&
                        (osc.StartTime < finish) && (osc.EndTime > start)))
                .Select(osc => new
                {
                    Id = oscdId++,
                    Order = osc.Order,
                    StartTime = osc.ConstraintUsage == (int)ConstraintUsage.Cnc ? osc.StartTime : osc.Order.StartTime,
                    EndTime = osc.ConstraintUsage == (int)ConstraintUsage.Cnc ? osc.EndTime : osc.Order.EndTime
                })
                .Where(oscd => (oscd.Order.Resource != null) && (oscd.StartTime < finish) && (oscd.EndTime > start))
                .ToList();
            data.resources.rows.AddRange(orders
                .Select(oscd => oscd.Order.Resource!)
                .Where(r => r.FiniteOrInfinite == (int)ResourceType.Finite)
                .Distinct()
                .Select(r => new CalendarResource()
                {
                    id = r.ResourceId,
                    name = r.Name,
                    image = r.GetImage()
                }));
            data.events.rows.AddRange(orders
                .Select(oscd => new CalendarEvent()
                {
                    id = oscd.Id,
                    orderId = oscd.Order.OrderId,
                    name = oscd.Order.ToString(),
                    startDate = oscd.StartTime!.Value,
                    endDate = oscd.EndTime!.Value,
                    iconCls = oscd.Order.GetIcon(),
                    dueDate = oscd.Order.DueDate,
                    finishedQuantity = oscd.Order.MidBatchQuantity,
                    isMilitary = oscd.Order.IsMilitary,
                    kitNumber = oscd.Order.KitNumber,
                    operationName = oscd.Order.OperationName,
                    opNo = oscd.Order.OpNo,
                    orderNo = oscd.Order.OrderNo,
                    partNo = oscd.Order.PartNo,
                    product = oscd.Order.Product,
                    projectCode = oscd.Order.ProjectCode,
                    quantity = oscd.Order.Quantity,
                    resource = oscd.Order.Resource!.Name
                }));
            int assId = 1;
            data.assignments.rows.AddRange(orders
                .Where(oscd => data.resources.rows.Any(rr => rr.id == oscd.Order.ResourceId))
                .Select(oscd => new CalendarAssignment()
                {
                    id = assId++,
                    eventId = oscd.Id,
                    resourceId = oscd.Order.ResourceId!.Value
                }));
            return data;
        }
    }
}
