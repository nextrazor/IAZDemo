using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public class BryntumGanttData
    {
        static BryntumGanttData? empty = new();
        public static BryntumGanttData Empty => empty;

        public BryntumResourceCollection resources { get; set; } = new();
        public BryntumEventCollection events { get; set; } = new();
        public BryntumAssignmentCollection assignments { get; set; } = new();
        public BryntumDependenciesCollection dependencies { get; set; } = new();
    }

    [Serializable]
    public class BryntumResourceCollection
    {
        public List<BryntumResource> rows { get; set; } = new ();
    }

    [Serializable]
    public class BryntumResource
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string iconCls { get; set; } = string.Empty;
        public bool image = false;
    }

    [Serializable]
    public class BryntumEventCollection
    {
        public List<BryntumEvent> rows { get; set; } = new();
    }

    [Serializable]
    public class BryntumEvent
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public double duration { get; set; }
        public string durationUnit { get; set; } = "hour";
        public string iconCls { get; set; } = string.Empty;
        public int percentDone { get; set; }
        public string eventColor { get; set; } = string.Empty;
    }

    [Serializable]
    public class BryntumAssignmentCollection
    {
        public List<BryntumAssignment> rows { get; set; } = new();
    }

    [Serializable]
    public class BryntumAssignment
    {
        public int id { get; set; }
        [JsonProperty(PropertyName = "event")]
        public int eventId { get; set; }
        public int resource { get; set; }
    }

    [Serializable]
    public class BryntumDependenciesCollection
    {
        public List<BryntumDependency> rows { get; set; } = new();
    }

    [Serializable]
    public class BryntumDependency
    {
        public int id { get; set; }
        public int fromEvent { get; set; }
        public int toEvent { get; set; }
        public int lag;
        public string lagUnit = "s";
    }
}
