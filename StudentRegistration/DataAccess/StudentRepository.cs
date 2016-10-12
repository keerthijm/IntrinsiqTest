using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static StudentRegistration.Models.StudentViewModels;

namespace StudentRegistration.DataAccess
{
    public class StudentRepository : IStudentRepository  
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StudentDbConnectionString"].ConnectionString;
        }

        public void AddStudent(Student student)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("AddStudentInformation2", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Forename", SqlDbType.VarChar, 255).Value = student.Forename;
                cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 255).Value = student.Surname;
                cmd.Parameters.Add("@PreferredName", SqlDbType.VarChar, 255).Value = student.PreferredName;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = student.DOB;
                cmd.Parameters.Add("@GenderId", SqlDbType.Int).Value = student.GenderId;
                cmd.Parameters.Add("@Nationality", SqlDbType.Int).Value = student.Nationality;
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 255).Value = student.MobileNumber;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = student.Email;
                cmd.Parameters.Add("@new_identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Prepare();
                var result = cmd.ExecuteScalar();
                cmd.Dispose();
                cmd = new SqlCommand("AddStudentFamilyInformation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = result;
                cmd.Parameters.Add("@MothersName", SqlDbType.VarChar, 255).Value = student.FamilyDetails.MothersName ?? string.Empty;
                cmd.Parameters.Add("@FathersName", SqlDbType.VarChar, 255).Value = student.FamilyDetails.FathersName ?? string.Empty;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = student.FamilyDetails.Address ?? string.Empty;
                cmd.Parameters.Add("@HomeTelephone", SqlDbType.VarChar).Value = student.FamilyDetails.HomeTelephone ?? string.Empty;
                cmd.Parameters.Add("@EmergencyNumber", SqlDbType.VarChar).Value = student.FamilyDetails.EmergencyNumber ?? string.Empty;
                cmd.Parameters.Add("@MainContact", SqlDbType.Int).Value = (student.FamilyDetails.MainContact == 0)? 1: student.FamilyDetails.MainContact;              
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = new SqlCommand("AddStudentPassportVisaInformation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = result;
                cmd.Parameters.Add("@PassportNumber", SqlDbType.VarChar, 255).Value = student.PassportDetails.PassportNumber ?? string.Empty;
                cmd.Parameters.Add("@PassportExpiryDate", SqlDbType.Date).Value = student.PassportDetails.PassportExpiryDate;
                cmd.Parameters.Add("@VisaNumber", SqlDbType.VarChar).Value = student.PassportDetails.VisaNumber ?? string.Empty;
                cmd.Parameters.Add("@VisaExpiryDate", SqlDbType.Date).Value = student.PassportDetails.VisaExpiryDate;              
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("GetStudents", conn);
                var reader = cmd.ExecuteReader();
                Student student = null;
                while (reader.Read())
                {
                    var studentID = Convert.ToInt32(reader["ID"]);                     
                    student = new Student();
                    student.Id = studentID;
                    student.Forename = reader["ForeName"].ToString();
                    student.Surname = reader["SurName"].ToString();
                    student.PreferredName = reader["PreferredName"].ToString();
                    student.DOB = DateTime.Parse(reader["DOB"].ToString());
                    student.GenderId = Convert.ToInt32(reader["GenderId"]);
                    student.Nationality = Convert.ToInt32(reader["Nationality"].ToString());
                    student.MobileNumber = reader["MobileNumber"].ToString();
                    student.Email = reader["Email"].ToString();
                    students.Add(student);
                }               

                reader.Close();
                cmd.Dispose();
            }
            return students;
        }


        public List<Gender> GetGenders()
        {
            List<Gender> genders = new List<Gender>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("GetGenders", conn);
                var reader = cmd.ExecuteReader();
                Gender gender = null;
                while (reader.Read())
                {
                    var genderID = Convert.ToInt32(reader["Id"]);
                    gender = new Gender();
                    gender.Id = genderID;
                    gender.GenderDescription = reader["GenderDescription"].ToString();
                    genders.Add(gender);
                }

                reader.Close();
                cmd.Dispose();
            }
            return genders;
        }


        public List<Nation> GetNations()
        {
            List<Nation> nations = new List<Nation>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("GetNations", conn);
                var reader = cmd.ExecuteReader();
                Nation nation = null;
                while (reader.Read())
                {
                    var nationID = Convert.ToInt32(reader["Id"]);
                    nation = new Nation();
                    nation.Id = nationID;
                    nation.Nationality = reader["Nationality"].ToString();
                    nations.Add(nation);
                }

                reader.Close();
                cmd.Dispose();
            }
            return nations;
        }

        public List<MainContact> GetMainContacts()
        {
            List<MainContact> mainContacts = new List<MainContact>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("GetMainContacts", conn);
                var reader = cmd.ExecuteReader();
                MainContact mainContact = null;
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["Id"]);
                    mainContact = new MainContact();
                    mainContact.Id = id;
                    mainContact.Contact = reader["Contact"].ToString();
                    mainContacts.Add(mainContact);
                }

                reader.Close();
                cmd.Dispose();
            }
            return mainContacts;
        }
    }
}