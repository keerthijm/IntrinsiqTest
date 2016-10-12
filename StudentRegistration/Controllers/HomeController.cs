using StudentRegistration.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static StudentRegistration.Models.StudentViewModels;

namespace StudentRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _repository;
        
        public HomeController()
        {
            _repository = new StudentRepository();
        }

        public ActionResult Index()
        {
            var students = _repository.GetStudents();
            return View(students.ToList());
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(_repository.GetGenders(), "Id", "GenderDescription");
            ViewBag.Nationality = new SelectList(_repository.GetNations(), "Id", "Nationality");
            ViewBag.MainContact = new SelectList(_repository.GetMainContacts(), "Id", "Contact");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Forename,Surname,PreferredName,DOB,GenderId,Nationality,MobileNumber,Email,FamilyDetails,PassportDetails")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.AddStudent(student);           
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(_repository.GetGenders(), "Id", "GenderDescription");
            ViewBag.Nationality = new SelectList(_repository.GetNations(), "Id", "Nationality");
            ViewBag.MainContact = new SelectList(_repository.GetMainContacts(), "Id", "Contact");
            return View(student);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}