namespace IAZBackend.FrontendData
{
    [Serializable]
    public class ColoredNamedValue
    {
        public string name;
        public double value;
        public string color;

        public ColoredNamedValue(string name, double value, string color)
        {
            this.name = name;
            this.value = value;
            this.color = color;
        }
    }
}
