package manager;

public class ConfigJson implements DeserializedJson {

    private OpenWeather openWeather;

    public OpenWeather getOpenWeather() {
        return openWeather;
    }

    public static class OpenWeather {
        private String apiKey;

        public String getApiKey() {
            return apiKey;
        }
    }
}
