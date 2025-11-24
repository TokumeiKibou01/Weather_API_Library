using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Weather_API_Library
{
    internal class OpenWeatherAPI
    {

        public static async Task<OpenWeatherAPI> GetInstanceAsync()
        {
            ConfigJson configJson = ConfigManager.GetConfig();
            var client = new HttpClient();
            HttpResponseMessage get_async = await client.GetAsync(
                            "https://api.openweathermap.org/data/2.5/forecast" +
                            "?lat=35.652799" +
                            "&lon=139.745367" +
                            "&appid=" + configJson.GetOpenWeather.GetApiKey +
                            "&lang=ja");
            string get_string = await get_async.Content.ReadAsStringAsync();

            OpenWeatherAPI openWeatherAPI = JsonConvert.DeserializeObject<OpenWeatherAPI>(get_string);
            return openWeatherAPI;
        }


        [JsonProperty("list")]
        public List<WeatherList> GetWeatherList { get; set; }

        internal class WeatherList {
            [JsonProperty("main")]
            public WeatherMain GetWeatherMain { get; set; }

            [JsonProperty("weather")]
            public List<Weather> GetWeather { get; set; }

            internal class WeatherMain {
                [JsonProperty("temp_min")]
                public float GetTempMin { get; set; }

                [JsonProperty("temp_max")]
                public float GetTempMax { get; set; }
            }

            internal class Weather
            {
                [JsonProperty("description")]
                public string GetDescription { get; set; }
            }
        }


    }
}
