using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using TuitionCalc.Models;

namespace TuitionCalc.Repositories {
    public interface ITuitionCalcRepository {
        FileContentResult ImportCSV(Stream csvFile);
    }

    public class TuitionCalcRepository : ITuitionCalcRepository {
        public FileContentResult ImportCSV(Stream importCSV) {
            StreamReader reader = new StreamReader(importCSV);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);

            return null;
        }
    }
}