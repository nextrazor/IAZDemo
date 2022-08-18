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

        public string  GetIcon()
        {
            string name = OperationName.ToLower();
            if (name.Contains("чпу")) return "b-fa b-fa-tachograph-digital";
            if (name.Contains("виброудар")) return "b-fa b-fa-arrows-to-dot";
            if (name.Contains("дробе")) return "b-fa b-fa-arrows-to-dot";
            if (name.Contains("гибк")) return "b-fa b-fa-bezier-curve";
            if (name.Contains("контрол")) return "b-fa b-fa-clipboard";
            if (name.Contains("консерв")) return "b-fa b-fa-can-food";
            if (name.Contains("маркир")) return "b-fa b-fa-stamp";
            if (name.Contains("пломб")) return "b-fa b-fa-award";
            if (name.Contains("подготов")) return "b-fa b-fa-hand-holding-box";
            if (name.Contains("правка")) return "b-fa b-fa-screwdriver-wrench";
            if (name.Contains("протир")) return "b-fa b-fa-broom";
            if (name.Contains("размет")) return "b-fa b-fa-highlighter-line";
            if (name.Contains("раскрой")) return "b-fa b-fa-scissors";
            if (name.Contains("сверлил")) return "b-fa b-fa-bore-hole";
            if (name.Contains("слесарн")) return "b-fa b-fa-fan";
            if (name.Contains("транспортир")) return "b-fa b-fa-truck";
            if (name.Contains("упаков")) return "b-fa b-fa-box";
            if (name.Contains("установ")) return "b-fa b-fa-arrow-down-to-line";
            if (name.Contains("фрезер")) return "b-fa b-fa-fan";
            return "b-fa b-fa-face-head-bandage";
        }
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

    public partial class Resource
    {
        public string GetImage()
        {
            if (ResourceGroup.Contains("DMF")) return "dmf.png";
            if (ResourceGroup.Contains("ВАК")) return "vacuum.png";
            if (ResourceGroup.Contains("ЭСТ")) return "rack.png";
            return string.Empty;
        }

        public string GetIcon()
        {
            return FiniteOrInfinite == (int)ResourceType.Finite ?
                "b-fa b-fa-tachograph-digital" :
                "b-fa b-fa-hands";
        }
    }
}
