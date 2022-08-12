using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public abstract class FrontendData
    {
        public abstract string GetJson();
    }
}
