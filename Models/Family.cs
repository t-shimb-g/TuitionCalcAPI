namespace TuitionCalc.Models {
    public class Family {
        public string FamilyName { get; set; } = "";
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
