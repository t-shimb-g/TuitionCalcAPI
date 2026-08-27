using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Repositories;

namespace TuitionCalc.Orchestrator {
    public interface IWeatherForecastOrchestrator {
        IEnumerable<WeatherForecast> GetForecast();
        FileContentResult ImportCSV(Stream importCSV);
    }

    public class WeatherForecastOrchestrator : IWeatherForecastOrchestrator {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastOrchestrator(IWeatherRepository weatherRepository) {
            _weatherRepository = weatherRepository;
        }

        public IEnumerable<WeatherForecast> GetForecast() {
            // Orchestration logic goes here
            var rawData = _weatherRepository.GenerateForecast();

            // You could add mapping, filtering, enrichment, logging, etc.
            return rawData;
        }

        public FileContentResult ImportCSV(Stream importCSV) {
            return null;
        }
    }

}