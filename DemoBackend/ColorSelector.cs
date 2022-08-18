namespace IAZBackend
{
    class ColorSelector
    {
        public static string[] GanttColors = new string[]
        {
//            "red",        // используется для подсветки заказа и не выбирается автоматически
            "pink",
            "purple",
            "violet",
            "indigo",
            "blue",
            "cyan",
            "teal",
            "green",
            "lime",
            "yellow",
            "orange",
            "deep-orange",
            "gray",
            "gantt-green"
        };
        public static string[] KanbanColors = new string[]
        {
            "red",
            "pink",
            "purple",
            "deep-purple",
            "indigo",
            "blue",
            "light-blue",
            "cyan",
            "teal",
            "green",
            "light-green",
            "lime",
            "yellow",
            "amber",
            "orange",
            "deep-orang"
        };

        string[] availableColors;

        public ColorSelector(string[] colors) => availableColors = colors;

        static Dictionary<string, int> tagColors = new Dictionary<string, int>();
        Random rnd = new();

        public string GetColor(string tag)
        {
            if (!tagColors.ContainsKey(tag))
            {
                int tagIndex = rnd.Next(availableColors.Length);
                tagColors.Add(tag, tagIndex);
            }
            return availableColors[tagColors[tag]];
        }
    }
}
