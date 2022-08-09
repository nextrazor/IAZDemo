using Newtonsoft.Json;

namespace IAZBackend.Config
{
    public class ConfigLoader
    {
        const string filePath = "config.json";
        static readonly Dictionary<string, string> configTextPalaceholder = new Dictionary<string, string>() 
        { 
            { "sqlServer", "---Enter server name---" } 
        };

        public ConfigData data = null!;

        public string SqlServer 
        { 
            get 
            {
                try
                {
                    if (data.sqlServer == configTextPalaceholder["sqlServer"])
                        throw new Exception($"Enter SQL Server instance name in {filePath}");
                    else return data.sqlServer;
                }
                catch
                {
                    throw new Exception($"Config file error, check {filePath}");
                }
            }
        }

        public ConfigLoader()
        {
            if (File.Exists(filePath))
                data = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(filePath)) ?? throw new Exception($"Config file error, check {filePath}");
            else
            {
                data = new ConfigData();
                data.sqlServer = configTextPalaceholder["sqlServer"];
                File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
            }
        }
    }
}
