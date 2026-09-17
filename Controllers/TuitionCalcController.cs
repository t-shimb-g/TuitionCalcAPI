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
        public IActionResult Post(IFormFile csvFile) { // eventually will return FileContentResult
            var pdfBytes = _tuitionCalcOrchestrator.ImportCSV(csvFile.OpenReadStream());
            return File(pdfBytes, "application/pdf", "tuition.pdf");
            // File(byte[] fileContents, string contentType, string fileDownloadName)
        }
    }
}