using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Sharp_Weather_API_Library.OpenWeatherAPI;
using static C_Sharp_Weather_API_Library.OpenWeatherAPI.WeatherList;

namespace C_Sharp_Weather_API_Library
{
    internal class WeatherCommand : CommandBase
    {

        void CommandBase.runCommand(string command)
        {
            if (command.Equals("get_weather"))
            {
                OpenWeatherAPI openWeatherAPI = OpenWeatherAPI.GetInstanceAsync().Result;
                WeatherList weatherList = openWeatherAPI.GetWeatherList[0];
                Weather weather = weatherList.GetWeather[0];
                WeatherMain weatherMain = weatherList.GetWeatherMain;

                Console.WriteLine("天気：" + weather.GetDescription + "\n" +
                    "最高気温：" + weatherMain.GetTempMax + "\n" +
                    "最低気温： " + weatherMain.GetTempMin + "\n");
            }
        }
    }
}
