namespace IAZBackend.FrontendData
{
    [Serializable]
    public class LoadingValue
    {
        public string MachineName;
        public string LoadingCategory;
        public double Value;

        public LoadingValue(string machineName, string loadingCategory, double value)
        {
            MachineName = machineName;
            LoadingCategory = loadingCategory;
            Value = value;
        }
    }
}
