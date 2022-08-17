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
}
