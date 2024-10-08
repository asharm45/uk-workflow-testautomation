using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorkflowSpecflowTests.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig()
        {
            var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
        }

        public static Users ReadCredentials()
        {
            var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/users.json");
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<Users>(configFile, jsonSerializerOptions);
        }
    }
}
