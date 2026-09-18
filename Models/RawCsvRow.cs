namespace TuitionCalc.Models {
    public class RawCsvRow {
        public string Family { get; set; }
        public string Student { get; set; }
        public char Grade { get; set; }
        public decimal? Scholarship { get; set; }
        public bool Member { get; set; }
        public decimal? RaiseRight { get; set; }
        public decimal? TuitionAssistance { get; set; }
        public decimal? WorkerDiscount { get; set; }
        public decimal? Miscellaneous { get; set; }
    }
}
