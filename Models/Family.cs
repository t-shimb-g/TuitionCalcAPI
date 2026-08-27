namespace TuitionCalc.Models {
    public class Family {
        public string FamilyName { get; set; } = ""; // Split last name and parent(s) name?
        public List<Student> Students { get; set; }
    }
}
