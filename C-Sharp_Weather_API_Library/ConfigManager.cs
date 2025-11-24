using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Weather_API_Library
{
    internal class ConfigManager
    {
        public ConfigManager() { }

        public static void CreateConfig()
        {
            if (!File.Exists("config.json"))
            {
                ConfigJson configJson = new ConfigJson();
                ConfigJson.OpenWeather openWeather = configJson.GetOpenWeather;
                openWeather.GetApiKey = "";

                var jsonWriteData = JsonConvert.SerializeObject(configJson);
                using (var sw = new StreamWriter(@"config.json", false, System.Text.Encoding.UTF8))
                {
                    sw.Write(jsonWriteData);
                }
            }
        }

        public static string GetRawJson()
        {
            using (var sr = new StreamReader("config.json"))
            {
                return sr.ReadToEnd();
            }
        }

        public static ConfigJson GetConfig()
        {
            ConfigJson configJson;
            using (var sr = new StreamReader(@"config.json", System.Text.Encoding.UTF8))
            {
                var jsonReadData = sr.ReadToEnd();
                configJson = JsonConvert.DeserializeObject<ConfigJson>(jsonReadData);
            }
            return configJson;
        }
    }

    [JsonObject("ConfigJson")]
    internal class ConfigJson
    {
        [JsonProperty("OpenWeather")]
        public OpenWeather GetOpenWeather { get; set; }
        public ConfigJson()
        {
            GetOpenWeather = new OpenWeather();
        }

        internal class OpenWeather
        {
            [JsonProperty("apiKey")]
            public string? GetApiKey { get; set;  }
        }
    }

}
