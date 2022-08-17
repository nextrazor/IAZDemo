namespace IAZBackend.Models.ApsEntities
{
    public partial class Dataset
    {
        static Dataset? currentDataset = null;
        public static Dataset CurrentDataset
        {
            get
            {
                if (currentDataset == null)
                {
                    using IAZ_ApsContext dbContext = new();
                    currentDataset = dbContext.Orders_Dataset
                        .FirstOrDefault(ds => ds.Name == "Schedule")
                        ?? throw new KeyNotFoundException("В БД APS не найден набор данных Schedule");
                }
                return currentDataset!;
            }
            set { currentDataset = value; }
        }
    }

    public partial class Order
    {
        /// <summary>
        /// Доля выполнения операции
        /// </summary>
        public double ProgressPercent
        {
            get
            {
                if ((Quantity <= 0) || (MidBatchQuantity <= 0))
                    return 0;
                if (MidBatchQuantity >= Quantity)
                    return 1;
                return MidBatchQuantity / Quantity;
            }
        }

        /// <summary>
        /// Общая плановая трудоемкость по партии
        /// </summary>
        public double FullLabour
        {
            get
            {
                switch (ProcessTimeType)
                {
                    case (int)ApsEntities.ProcessTimeType.TimePerItem:
                        return Quantity * OpTimePerItem;
                    case (int)ApsEntities.ProcessTimeType.TimePerBatch:
                        return BatchTime;
                    default:
                        throw new NotSupportedException($"Неподдерживаемый тип нормирования времени - {ProcessTimeType}");
                }
            }
        }

        /// <summary>
        /// Выполненная трудоемкость по партии
        /// </summary>
        public double ProducedLabour => FullLabour * ProgressPercent;
    }

    public partial class SecConstraint
    {
        WorkerData? personalData;
        public WorkerData PersonalData
        {
            get
            {
                if (personalData == null)
                {
                    personalData = new();
                    string[] parts = Name.Split(' ');
                    if (parts.Length > 0) personalData.Number = parts[0];
                    if (parts.Length > 1) personalData.LastName = parts[1];
                    if (parts.Length > 2) personalData.FirstName = parts[2];
                    if (parts.Length > 3) personalData.MiddleName = parts[3];
                }
                return personalData!;
            }
        }

        public class WorkerData
        {
            public string Number = string.Empty;
            public string LastName = string.Empty;
            public string FirstName = string.Empty;
            public string MiddleName = string.Empty;
        }
    }
}
