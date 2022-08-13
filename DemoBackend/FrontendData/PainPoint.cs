namespace IAZBackend.FrontendData
{
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
        Low,
        /// <summary> Желательно исправить </summary>
        Normal,
        /// <summary> Серьезное нарушение KPI </summary>
        High,
        /// <summary> Недопустимо выдавать в работу </summary>
        Critical
    }
}
