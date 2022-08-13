namespace IAZBackend.FrontendData
{
    [Serializable]
    public class LoadingValue
    {
        public string machineName;
        public string loadingCategory;
        public double value;

        public LoadingValue(string machineName, string loadingCategory, double value)
        {
            this.machineName = machineName;
            this.loadingCategory = loadingCategory;
            this.value = value;
        }
    }
}
