using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class MasterKanbanController
    {
        public static List<KanbanColumnData> GetKanbanColumns(int groupNumber)
        {
            ColorSelector colorSelector = new(ColorSelector.KanbanColors);

            using IAZ_ApsContext dbContext = new();
            return dbContext.Workgroups
                .Where(wg => wg.Number == groupNumber)
                .SelectMany(wg => wg.Workers)
                .OrderBy(wr => wr.ProfessionCode)
                .Select(wr => new KanbanColumnData()
                {
                    id = wr.SecConstraintId.ToString(),
                    text = $"{wr.PersonalData.Number} {wr.PersonalData.LastName} {wr.PersonalData.FirstName}",
                    color = colorSelector.GetColor(wr.ProfessionCode),
                    tooltip = $"{wr.Name}<br>Код профессии: {wr.ProfessionCode}<br>Произв. группы: {GetWorkerGroupsStr(wr)}"
                })
                .ToList();
        }

        private static object GetWorkerGroupsStr(SecConstraint worker)
        {
            if (!worker.Workgroups.Any())
                return "нет";
            string s = worker.Workgroups
                .OrderBy(wg => wg.Number)
                .Aggregate("", (seed, gr) => $"{seed}{gr.Number}, ");
            return s.Substring(0, s.Length - 2);
        }

        public static KanbanTaskData GetKanbanTasks(Dataset dataset, int groupNumber, DateTime date)
        {
            using IAZ_ApsContext dbContext = new();
            KanbanTaskData data = new();
            DateTime start = date.Date;
            DateTime finish = start.AddDays(1);
            var workers = dbContext.Workgroups
                .Where(wg => wg.Number == groupNumber)
                .SelectMany(wg => wg.Workers)
                .ToList();
            int assId = 1;
            int orderId = 1;
            foreach (SecConstraint worker in workers)
            {
                foreach(var workerOrder in worker
                    .OrderSecConstraints
                    .Where(osc => (osc.ConstraintUsage == (int)ConstraintUsage.IncrementForProcessTime) ||
                        ((osc.ConstraintUsage == (int)ConstraintUsage.Cnc) &&
                            (osc.StartTime < finish) && (osc.EndTime > start)))
                    .Select(osc => new
                    {
                        Order = osc.Order,
                        StartTime = osc.ConstraintUsage == (int)ConstraintUsage.Cnc ? osc.StartTime : osc.Order.StartTime,
                        EndTime = osc.ConstraintUsage == (int)ConstraintUsage.Cnc ? osc.EndTime : osc.Order.EndTime
                    })
                    .Where(oscd => (oscd.Order.Resource != null) && (oscd.StartTime < finish) && (oscd.EndTime > start) && (oscd.Order.MidBatchQuantity < oscd.Order.Quantity))
                    .OrderBy(oscd => oscd.StartTime))
                {
                    data.assignments.rows.Add(new KanbanAssignment()
                    {
                        id = assId++,
                        eventId = orderId,
                        resource = workerOrder.Order.ResourceId!.Value
                    });
                    data.tasks.rows.Add(new KanbanTask()
                    {
                        id = orderId++,
                        name = workerOrder.Order.ToString(),
                        status = worker.SecConstraintId.ToString(),
                        start = workerOrder.StartTime!.Value.ToString("HH:mm"),
                        end = workerOrder.EndTime!.Value.ToString("HH:mm"),
                        labour = (workerOrder.EndTime!.Value - workerOrder.StartTime!.Value).ToString("hh\\:mm"),
                        orderNo = workerOrder.Order.OrderNo,
                        partNo = workerOrder.Order.PartNo,
                        opNo = workerOrder.Order.OpNo,
                        operationName = workerOrder.Order.OperationName,
                        progress = workerOrder.Order.ProgressPercent * 100
                    });
                }
            }
            var resources = data.assignments.rows
                .Select(ass => ass.resource)
                .Distinct()
                .Select(resId => dbContext.Resources.Single(res => res.ResourceId == resId))
                .ToList();
            data.resources.rows.AddRange(resources
                .Select(res => new KanbanResource()
                 {
                    id = res.ResourceId,
                    name = res.Name,
                    resourceGroup = res.ResourceGroup,
                    image = res.GetImage()
                }));
            KanbanResource? manualResource = data.resources.rows
                .FirstOrDefault(row => row.name.StartsWith("_"));
            if (manualResource != null)
            {
                data.resources.rows.Remove(manualResource!);
                data.assignments.rows.RemoveAll(ass => ass.resource == manualResource!.id);
            }
            return data;
        }
    }
}
