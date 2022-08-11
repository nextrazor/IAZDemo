namespace IAZBackend
{
    [Serializable]
    public class Response
    {
        public AnalysisData data;

        public Response(FrontendData[] data, FrontendData[] data2)
        {
            this.data = new AnalysisData(data, data2);
        }
    }

    [Serializable]
    public class AnalysisData
    {
        public FrontendData[] dataSet;
        public FrontendData[] dataSet2;

        public AnalysisData(FrontendData[] data, FrontendData[] data2)
        {
            dataSet = data;
            dataSet2 = data2;
        }
    }

    [Serializable]
    public class FrontendData
    {
        public string name;
        public int value;

        public FrontendData(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
