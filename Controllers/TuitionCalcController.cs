using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Orchestrator;

namespace TuitionCalc.Controllers {
    [ApiController]
    public class TuitionCalcController : ControllerBase {
        private readonly ITuitionCalcOrchestrator _tuitionCalcOrchestrator;

        public TuitionCalcController(ITuitionCalcOrchestrator tuitionCalcOrchestrator) {
            _tuitionCalcOrchestrator = tuitionCalcOrchestrator;
        }

        [HttpGet("health")]
        public string Get() {
            return "Get route is working";
        }
        [HttpPost("submitCSV")]
        public IEnumerable<Family> Post(IFormFile csvFile) { // eventually will return FileContentResult
            return _tuitionCalcOrchestrator.ImportCSV(csvFile.OpenReadStream());
        }
    }
}