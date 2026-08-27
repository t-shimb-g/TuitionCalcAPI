using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;
using TuitionCalc.Repositories;

namespace TuitionCalc.Orchestrator {
    public interface ITuitionCalcOrchestrator {
        FileContentResult ImportCSV(Stream importCSV);
    }

    public class TuitionCalcOrchestrator : ITuitionCalcOrchestrator
    {
        private readonly ITuitionCalcRepository _tuitionCalcRepository;

        public TuitionCalcOrchestrator(ITuitionCalcRepository tuitionCalcRepository) {
            _tuitionCalcRepository = tuitionCalcRepository;
        }

        public FileContentResult ImportCSV(Stream importCSV) {
            return _tuitionCalcRepository.ImportCSV(importCSV);
        }
    }

}