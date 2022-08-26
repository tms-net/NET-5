namespace Weather.Web.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> FindForecastAsync(string search, DateTime? forecastDate = null);
    }

    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly GeoCodeClient _geoCodeClient = new();

        public async Task<WeatherForecast> FindForecastAsync(string search, DateTime? forecastDate = default)
        {
            forecastDate ??= DateTime.UtcNow;

            var locationInfo = await _geoCodeClient.LookupAsync(search);

            // TODO: get forecast for location

            return new WeatherForecast();
        }
    }

    /// <summary>
    /// TODO: define model for forecast
    /// </summary>
    public class WeatherForecast
    {
    }
}
