using System.Reflection;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public class PainPointCollector
    {
        public PainPoint[] GetAllPainPoints(Dataset dataset)
        {
            List<PainPoint> painPoints = new List<PainPoint>();
            foreach (Type inhType in GetInheritedClasses())
            {
                PainPointCollector obj = (PainPointCollector?)Activator.CreateInstance(inhType) ??
                    throw new Exception($"Не удалось создать объект типа {inhType.Name}");
                painPoints.AddRange(obj.GetPainPoints(dataset)); ;
            }
            return painPoints.OrderByDescending(pp => (int)pp.severity).ToArray();
        }

        Type[] GetInheritedClasses()
        {
            Type thisType = this.GetType();
            Assembly thisAssembly = Assembly.GetAssembly(thisType) ?? throw new Exception("Не определена сборка для типа PainPointCollector");
            return thisAssembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(thisType)).ToArray();
        }

        protected virtual PainPoint[] GetPainPoints(Dataset dataset) => new PainPoint[] { };
    }

    class PainPointLateOrders : PainPointCollector
    {
        protected override PainPoint[] GetPainPoints(Dataset dataset)
        {
            int X = 3;      // кол-во дней просрочки для генерации проблемной точки

            using var dbContext = new IAZ_ApsContext();
            var lastOpers = dbContext.Orders
                .Where(ord => ord.DatasetId == dataset.DatasetId)
                .GroupBy(ord => ord.OrderNo)
                .Select(og => og.OrderByDescending(op => op.OpNo).First())
                .AsEnumerable();
            var lateOrders = lastOpers
                .Where(op => op.EndTime.HasValue && op.DueDate.HasValue && (op.EndTime!.Value > op.DueDate!.Value.AddDays(X)))
                .AsEnumerable();
            string[] tags = new string[] { PainPointSeverity.High.ToString(), "Заказ" };
            return lateOrders
                .Select(ord => new PainPoint(Guid.NewGuid().ToString(), tags, PainPointSeverity.High,
                    $"Заказ {ord.OrderNo} просрочен на {(ord.EndTime!.Value - ord.DueDate!.Value).Days} дней"))
                .ToArray();
        }
    }

    class PainPointNotSchedOrders : PainPointCollector
    {
        protected override PainPoint[] GetPainPoints(Dataset dataset)
        {
            using var dbContext = new IAZ_ApsContext();
            var notSchedOrderNums = dbContext.Orders
                .Where(ord => (ord.DatasetId == dataset.DatasetId) && (ord.Resource == null))
                .GroupBy(ord => ord.OrderNo)
                .Select(gr => gr.Key)
                .AsEnumerable();
            string[] tags = new string[] { PainPointSeverity.High.ToString(), "Заказ" };
            return notSchedOrderNums
                .Select(orderNo => new PainPoint(Guid.NewGuid().ToString(), tags, PainPointSeverity.High,
                    $"Заказ {orderNo} не спланирован"))
                .ToArray();
        }
    }

    class PainPointLongSlackTime : PainPointCollector
    {
        protected override PainPoint[] GetPainPoints(Dataset dataset)
        {
            using var dbContext = new IAZ_ApsContext();
            List<PainPoint> res = new();
            foreach(var ordOpers in dbContext.Orders
                .Where(ord => (ord.DatasetId == dataset.DatasetId))
                .AsEnumerable()
                .GroupBy(ord => ord.OrderNo))
            {
                res.AddRange(GetLongSlackTimeInOrder(ordOpers));
            }
            return res.ToArray();
        }

        private static List<PainPoint> GetLongSlackTimeInOrder(IGrouping<string, Order> ordOpers)
        {
            int X = 7;      // кол-во дней пролеживания для генерации проблемной точки

            List<PainPoint> res = new();
            string[] tags = new string[] { PainPointSeverity.Low.ToString(), "Заказ" };
            Order? prevOper = null;
            foreach (Order oper in ordOpers.OrderBy(op => op.OpNo))
            {
                if (!oper.StartTime.HasValue)
                    break;
                if ((prevOper != null) && (oper.StartTime.Value > prevOper!.EndTime!.Value.AddDays(X)))
                    res.Add(new PainPoint(Guid.NewGuid().ToString(), tags, PainPointSeverity.Low,
                        $"Заказ {oper.OrderNo} пролеживает {(oper.StartTime!.Value - prevOper!.EndTime!.Value).Days} дней после операции {prevOper!.OpNo}"));
                prevOper = oper;
            }
            return res;
        }
    }

    [Serializable]
    public class PainPoint
    {
        public string guid;
        public string[] category = null!;
        public PainPointSeverity severity;
        public string message = null!;

        public PainPoint(string guid, string[] category, PainPointSeverity severity, string message)
        {
            this.guid = guid;
            this.category = category;
            this.severity = severity;
            this.message = message;
        }
    }

    [Serializable]
    public enum PainPointSeverity
    {
        /// <summary> Привлечение внимания </summary>
        Low = 0,
        /// <summary> Желательно исправить </summary>
        Normal = 1,
        /// <summary> Серьезное нарушение KPI </summary>
        High = 2,
        /// <summary> Недопустимо выдавать в работу </summary>
        Critical = 3
    }
}
