using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class StudentViewModels
    {
        public partial class Student
        {
            public Student()
            {
                this.FamilyDetails = new FamilyDetail();
                this.PassportDetails = new PassportDetail();
            }

            public int Id { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
            public string PreferredName { get; set; }

            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public Nullable<System.DateTime> DOB
            {
                get; set;
            }
            public Nullable<int> GenderId { get; set; }
            public Nullable<int> Nationality { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }

            public virtual FamilyDetail FamilyDetails { get; set; }
            public virtual Gender Gender { get; set; }
            public virtual Nation Nation { get; set; }
            public virtual PassportDetail PassportDetails { get; set; }
        }
    }
}