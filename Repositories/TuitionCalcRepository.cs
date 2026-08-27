using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TuitionCalc.Models;

namespace TuitionCalc.Repositories {
    public interface ITuitionCalcRepository {
        IEnumerable<RawCsvRow> ProcessCSV(Stream importCSV);
        IEnumerable<Family> ProduceJSON(IEnumerable<RawCsvRow> rawRows);
    }

    public class TuitionCalcRepository : ITuitionCalcRepository {
        public class RawCsvRowMap : ClassMap<RawCsvRow> {
            public RawCsvRowMap() {
                Map(m => m.Family).Name("family");
                Map(m => m.Student).Name("student");
                Map(m => m.Grade).Name("Grade");
                Map(m => m.HeritageScholarship).Name("Heritage Scholarship");
                Map(m => m.RaiseRight).Name("raiseright");
                Map(m => m.TuitionAssistance).Name("tuition assts");
                Map(m => m.CalledWorkerDiscount).Name("called worker discount");

                // If any text in field => true
                Map(m => m.GslcMember)
                    .Name("GSLC member")
                    .Convert(args => !string.IsNullOrWhiteSpace(args.Row.GetField("GSLC member")));
                    // ^^^ Retrieves raw CSV value, checks if it contains ANY text, if so -> true, else false
            }
        }

        public IEnumerable<RawCsvRow> ProcessCSV(Stream importCSV) {
            StreamReader reader = new StreamReader(importCSV);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<RawCsvRowMap>();

            var rawRows = csv.GetRecords<RawCsvRow>().ToList();

            return rawRows;
        }

        public IEnumerable<Family> ProduceJSON(IEnumerable<RawCsvRow> rawRows) {
            var families = new List<Family>();
            Family currentFamily = null;

            foreach (RawCsvRow row in rawRows) {
                if (!string.IsNullOrWhiteSpace(row.Family)) {
                    currentFamily = new Family { FamilyName = row.Family, Students = new List<Student>() };
                    families.Add(currentFamily);
                }

                var student = new Student {
                    Name = row.Student,
                    Grade = row.Grade,
                    HeritageScholarship = row.HeritageScholarship.GetValueOrDefault(), // Sets to 0 if null, otherwise sets to value
                    GSLChurchMember = row.GslcMember,
                    RaiseRight = row.RaiseRight.GetValueOrDefault(),
                    TuitionAssistance = row.TuitionAssistance.GetValueOrDefault(),
                    CalledWorkerDiscount = row.CalledWorkerDiscount.GetValueOrDefault()
                };

                currentFamily.Students.Add(student);
            }

            return families;
        }
    }
}