using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public class CalendarTaskData
    {
        public CalendarResourceList resources { get; set; } = new();
        public CalendarEventList events { get; set; } = new();
        public CalendarAssignmentList assignments { get; set; } = new();
    }

    [Serializable]
    public class CalendarResourceList
    {
        public List<CalendarResource> rows { get; set; } = new();
    }

    [Serializable]
    public class CalendarResource
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string image { get; set; } = null!;
    }

    [Serializable]
    public class CalendarEventList
    {
        public List<CalendarEvent> rows { get; set; } = new();
    }

    [Serializable]
    public class CalendarEvent
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string name { get; set; } = null!;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string iconCls { get; set; } = null!;
    }

    [Serializable]
    public class CalendarAssignmentList
    {
        public List<CalendarAssignment> rows { get; set; } = new();
    }

    [Serializable]
    public class CalendarAssignment
    {
        public int id { get; set; }
        public int eventId { get; set; }
        public int resourceId { get; set; }
    }
}
