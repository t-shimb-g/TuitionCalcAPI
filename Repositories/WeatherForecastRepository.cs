using TuitionCalc.Models;

namespace TuitionCalc.Repositories {
    public interface IWeatherRepository {
        IEnumerable<WeatherForecast> GenerateForecast();
    }

    public class WeatherRepository : IWeatherRepository {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
                "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public IEnumerable<WeatherForecast> GenerateForecast() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }
    }
}