namespace IAZBackend.FrontendData
{
    [Serializable]
    public class NamedValue
    {
        public string name;
        public double value;

        public NamedValue(string name, double value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
