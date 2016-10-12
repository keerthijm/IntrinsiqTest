using System;
using static StudentRegistration.Models.StudentViewModels;

namespace StudentRegistration.Models
{
    public class PassportDetail
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string VisaNumber { get; set; }
        public DateTime VisaExpiryDate { get; set; }
               
    }
}