using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Orchestrator;

namespace TuitionCalc.Controllers {
    [ApiController]
    public class WeatherForecastController : ControllerBase {
        private readonly IWeatherForecastOrchestrator _weatherForecastOrchestrator;

        public WeatherForecastController(IWeatherForecastOrchestrator weatherForecastOrchestrator) {
            _weatherForecastOrchestrator = weatherForecastOrchestrator;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return _weatherForecastOrchestrator.GetForecast();
        }
    }
}