namespace IAZBackend.FrontendData
{
    [Serializable]
    public class NamedValue
    {
        public string Name;
        public double Value;

        public NamedValue(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
