namespace StudentRegistration.Models
{
    public class FamilyDetail
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string Address { get; set; }
        public string HomeTelephone { get; set; }
        public string EmergencyNumber { get; set; }
        public int MainContact { get; set; }
    }
}