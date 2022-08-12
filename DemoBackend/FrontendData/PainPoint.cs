namespace IAZBackend.FrontendData
{
    [Serializable]
    public class PainPoint
    {
        public Guid Guid;
        public string Category = null!;
        public PainPointSeverity Severity;
        public string Message = null!;

        public PainPoint(Guid guid, string category, PainPointSeverity severity, string message)
        {
            Guid = guid;
            Category = category;
            Severity = severity;
            Message = message;
        }
    }

    [Serializable]
    public enum PainPointSeverity
    {
        /// <summary> Привлечение внимания </summary>
        Low,
        /// <summary> Желательно исправить </summary>
        Normal,
        /// <summary> Серьезное нарушение KPI </summary>
        High,
        /// <summary> Недопустимо выдавать в работу </summary>
        Critical
    }
}
