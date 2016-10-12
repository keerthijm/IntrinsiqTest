using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentRegistration.Models.StudentViewModels;

namespace StudentRegistration.DataAccess
{
    interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudent(int id);
        List<Student> GetStudents();
        List<Gender> GetGenders();
        List<Nation> GetNations();
        List<MainContact> GetMainContacts();
    }
}
