using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace IAZBackend.Config
{
    public class ConfigLoader
    {
        const string filePath = "config.json";
        static readonly Dictionary<string, string> configTextPalaceholder = new Dictionary<string, string>() 
        { 
            { "sqlServer", "---Enter server name---" },
            { "allowedURL", "---Enter URL--- Default:http://localhost:8000" },
            { "policyName", "---Enter Polycy Name--- Default:_myAllowSpecificOrigins" }
        };

        public ConfigData data = null!;

        public string SqlServer { get { return LoadData("sqlServer"); }}
        public string AllowedURL { get { return LoadData("allowedURL"); } }
        public string PolicyName { get { return LoadData("policyName"); } }

        private string LoadData([NotNull] string field)
        {
            Type type = data.GetType();

            try
            {
                FieldInfo property = type.GetField(field) ?? throw new Exception($"Missing property \"{field}\" in ConfigurationData");
                object valueObj = property.GetValue(data) ?? throw new Exception($"Config file error, check {field} in {filePath}");
                string value = valueObj.ToString() ?? throw new Exception($"Config file error, check {field} in {filePath}");

                if (value.Contains("Default:"))
                    return value.Split("Default:")[1];
                else if (value == configTextPalaceholder[field])
                    throw new Exception($"Enter {field} in {filePath}");
                else 
                    return data.sqlServer;
            }
            catch
            {
                throw new Exception($"Config file error, check {filePath}");
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
                data.allowedURL = configTextPalaceholder["allowedURL"];
                data.policyName = configTextPalaceholder["policyName"];
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(filePath, json);
            }
        }
    }
}
