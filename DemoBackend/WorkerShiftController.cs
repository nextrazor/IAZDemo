using IAZBackend.FrontendData;
using DemoBackend.Models;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class WorkerShiftController
    {
        public static TimeSpan ShiftStart { get => TimeSpan.FromHours(7.5); }

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

        public static List<CncLoadingData> GetLoadingData(string cncInvNumber, DateTime month)
        {
            using IAZ_ApsContext dbContext = new();
            var resource = dbContext.Resources
                .FirstOrDefault(res => res.Name.StartsWith(cncInvNumber));
            if (resource == null)
                return new List<CncLoadingData>();
            DateTime start = new DateTime(month.Year, month.Month, 1) + ShiftStart;
            DateTime finish = start.AddMonths(1);
            var orders = resource.Orders
                .Where(ord => (ord.StartTime < finish) && (ord.EndTime > start) && (ord.StartTime < ord.EndTime))
                .ToList();
            List<CncLoadingData> res = new();
            DateTime day = start;
            DateTime nextDay;
            while (day < finish)
            {
                nextDay = day.AddDays(1);
                double dayHours = orders
                    .Where(ord => (ord.StartTime < nextDay) && (ord.EndTime > day))
                    .Select(ord => new
                    {
                        Start = ord.StartTime < day ? day : ord.StartTime!.Value,
                        Finish = ord.EndTime > nextDay ? nextDay : ord.EndTime!.Value
                    })
                    .Sum(dd => (dd.Finish - dd.Start).TotalHours);
                if (dayHours > 0)
                    res.Add(new CncLoadingData()
                    {
                        date = day.Date,
                        hours = dayHours < 0.01 ? 0.01 : Math.Round(dayHours, 2),
                    });
                day = nextDay;
            }
            return res;
        }
    }
}
