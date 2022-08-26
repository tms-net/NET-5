namespace Weather.Web.Models
{
    public class WeatherViewModel
    {
        /// <summary>
        /// Место
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Температура в цельсиях
        /// </summary>
        public int CurrentTemperature { get; set; }

        public WeeklyForecastViewModel[] WeeklyForecast { get; set; }

        public DailyForecastViewModel[] DailyForecast { get; set; }

        public WeatherType WeatherType { get; set; }

    }

    public class WeeklyForecastViewModel
    {
        public int Temperature { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public WeatherType WeatherType { get; set; }
    }

    public class DailyForecastViewModel
    {
        public int Temperature { get; set; }

        public DateTime Time { get; set; }

        public WeatherType WeatherType { get; set; }

    }

    public enum WeatherType : int
    {
        Sunny = 0,
        Cloudy,
        Rain
    }
}
