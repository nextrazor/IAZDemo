using IAZBackend.FrontendData;
using DemoBackend.Models;

namespace IAZBackend
{
    public static class WorkerShiftController
    {
        public static List<WorkerMonthShiftData> GetShiftData(string cncInvNumber, DateTime month)
        {
            using IAZ_PBDContext dbContext = new();
            List<WorkerMonthShiftData> res = new();
            DateTime start = new DateTime(month.Year, month.Month, 1);
            DateTime finish = start.AddMonths(1);
            DemoBackend.Models.Resource? resource = dbContext.Resources
                .FirstOrDefault(res => res.InventoryNumber == cncInvNumber);
            if (resource != null)
            {
                foreach (var wshifts in dbContext.WorkerEquipmentShifts
                    .Where(wes => (wes.Idresource == resource.Idresource) &&
                        (wes.Date >= start) && (wes.Date < finish))
                    .ToList()
                    .GroupBy(wes => wes.WorkerCode))
                {
                    Worker? worker = dbContext.Workers
                        .FirstOrDefault(w => w.WorkerCode == wshifts.Key);
                    if (worker == null)
                        continue;
                    res.Add(new WorkerMonthShiftData()
                    {
                        workerCode = worker.WorkerCode,
                        fio = worker.Fio,
                        shifts = wshifts
                            .Select(ws => new WorkerShiftData()
                            {
                                date = ws.Date,
                                shift = ws.Shift ??
                                    throw new ApplicationException("Поле Shift в таблице WorkerEquipmentShifts не заполнено"),
                                hours = ws.Hours ??
                                    throw new ApplicationException("Поле Hours в таблице WorkerEquipmentShifts не заполнено")
                            })
                            .ToList()
                    });
                }
            }
            return res;
        }
    }
}
