using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public class KanbanColumnData
    {
        public string id { get; set; } = null!;
        public string text { get; set; } = null!;
        public string color { get; set; } = "gray";
        public string tooltip { get; set; } = string.Empty;
    }

    [Serializable]
    public class KanbanTaskData
    {
        public KanbanResourceList resources { get; set; } = new();
        public KanbanTaskList tasks { get; set; } = new();
        public KanbanAssignmentList assignments { get; set; } = new();
    }

    [Serializable]
    public class KanbanResourceList
    {
        public List<KanbanResource> rows { get; set; } = new();
    }

    [Serializable]
    public class KanbanResource
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
    }

    [Serializable]
    public class KanbanTaskList
    {
        public List<KanbanTask> rows { get; set; } = new();
    }

    [Serializable]
    public class KanbanTask
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string status { get; set; } = null!;
    }

    [Serializable]
    public class KanbanAssignmentList
    {
        public List<KanbanAssignment> rows { get; set; } = new();
    }

    [Serializable]
    public class KanbanAssignment
    {
        public int id { get; set; }
        [JsonProperty(PropertyName = "event")]
        public int eventId { get; set; }
        public int resource { get; set; }
    }
}
