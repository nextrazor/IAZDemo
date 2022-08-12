using Newtonsoft.Json;

namespace IAZBackend
{
    [Serializable]
    public abstract class PageData
    {
        public abstract string GetJson();
    }

    [Serializable]
    public class AnalisysPiesData : PageData
    {
        public FrontendData[] dataSet;
        public FrontendData[] dataSet2;

        public AnalisysPiesData(FrontendData[] data, FrontendData[] data2)
        {
            dataSet = data;
            dataSet2 = data2;
        }

        public override string GetJson()
        {
            return $"{{\"data\": {JsonConvert.SerializeObject(this)}}}";
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
