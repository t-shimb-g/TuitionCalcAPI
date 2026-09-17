namespace TuitionCalc.Models {
    public class Student {
        public string Name { get; set; } = "";
        public char Grade { get; set; }
        public decimal HeritageScholarship { get; set; } = 0;
        public bool GSLChurchMember { get; set; } = false;
        public decimal RaiseRight { get; set; } = 0;
        public decimal TuitionAssistance { get; set; } = 0;
        public decimal CalledWorkerDiscount { get; set; } = 0;
        public decimal Miscellaneous {  get; set; } = 0;
    }
}
