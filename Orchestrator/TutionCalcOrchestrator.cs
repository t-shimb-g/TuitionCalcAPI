using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Repositories;

namespace TuitionCalc.Orchestrator {
    public interface ITuitionCalcOrchestrator {
        IEnumerable<Family> ImportCSV(Stream importCSV); // eventually will return FileContentResult
    }

    public class TuitionCalcOrchestrator : ITuitionCalcOrchestrator
    {
        private readonly ITuitionCalcRepository _tuitionCalcRepository;

        public TuitionCalcOrchestrator(ITuitionCalcRepository tuitionCalcRepository) {
            _tuitionCalcRepository = tuitionCalcRepository;
        }

        public IEnumerable<Family> ImportCSV(Stream importCSV) { // eventually will return FileContentResult
            var processedCSV = _tuitionCalcRepository.ProcessCSV(importCSV);
            return _tuitionCalcRepository.ProduceJSON(processedCSV);
        }
    }
}