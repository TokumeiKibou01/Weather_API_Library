package command;

import api.OpenWeatherAPI;

import java.util.List;

public class WeatherCommand implements CommandBase {

    @Override
    public void runCommand(String name) {
        if (name.equalsIgnoreCase("get_weather")) {
            OpenWeatherAPI openWeather = OpenWeatherAPI.getInstance(35.41, 139.41); //東京
            for (OpenWeatherAPI.WeatherList weatherList : openWeather.getWeatherList()) {
                OpenWeatherAPI.WeatherList.Weather weather = weatherList.getWeather().getFirst();
                OpenWeatherAPI.WeatherList.Main weatherMain = weatherList.getMain();
                System.out.print("\n----------" + "\n" +
                        "時間：" + weatherList.getLocalDateTime() + "\n" +
                        "天気: " + weather.getDescription() + "\n" +
                        "最高気温: " + weatherMain.getTempMax(false) + "（元のデータ: " + weatherMain.getTempMax(true) + ")" + "\n" +
                        "最低気温: " + weatherMain.getTempMin(false) + "（元のデータ: " + weatherMain.getTempMin(true) + ")" + "\n" +
                        "湿度：　" + weatherMain.getHumidity() + "\n" +
                        "気圧：　" + weatherMain.getPressure() + "\n" +
                        "海面気圧： " + weatherMain.getSeaLevel() + "\n" +
                        "地点気圧：　" + weatherMain.getGrndLevel() + "\n" +
                        "----------" + "\n");
            }
        }
    }

}
