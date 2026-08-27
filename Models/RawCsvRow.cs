namespace TuitionCalc.Models {
    public class RawCsvRow {
        public string Family { get; set; }
        public string Student { get; set; }
        public char Grade { get; set; }
        public decimal? HeritageScholarship { get; set; }
        public bool GslcMember { get; set; }
        public decimal? RaiseRight { get; set; }
        public decimal? TuitionAssistance { get; set; }
        public decimal? CalledWorkerDiscount { get; set; }
    }
}
