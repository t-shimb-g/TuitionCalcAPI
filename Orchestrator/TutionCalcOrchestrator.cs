using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Repositories;

namespace TuitionCalc.Orchestrator {
    public interface ITuitionCalcOrchestrator {
        byte[] ImportCSV(Stream importCSV); // eventually will return FileContentResult
    }

    public class TuitionCalcOrchestrator : ITuitionCalcOrchestrator
    {
        private readonly ITuitionCalcRepository _tuitionCalcRepository;

        public TuitionCalcOrchestrator(ITuitionCalcRepository tuitionCalcRepository) {
            _tuitionCalcRepository = tuitionCalcRepository;
        }

        public byte[] ImportCSV(Stream importCSV) { // eventually will return FileContentResult
            var processedCSV = _tuitionCalcRepository.ProcessCSV(importCSV);
            var families = _tuitionCalcRepository.ProduceJSON(processedCSV);
            var pdfBytes = _tuitionCalcRepository.BuildFamiliesPdf(families);
            return pdfBytes;
            _tuitionCalcRepository.CalcTuition(families);
        }
    }
}