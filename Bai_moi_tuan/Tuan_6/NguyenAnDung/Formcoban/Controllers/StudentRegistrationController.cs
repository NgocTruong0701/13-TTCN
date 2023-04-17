using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Formcoban.Models;

namespace Formcoban.Controllers
{
    public class StudentRegistrationController : Controller
    {
        // GET: StudentRegistration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regis(Student s)
        {
            return View(s);
        }

        public ActionResult Regis2(FormCollection f)
        {
            Student s = new Student();
            s.name = f["name"];
            s.gender = f["gender"];
            s.email = f["email"];
            s.addr = f["addr"];

            string temp = "";
            if (f["Java core"] == "true,false")
                temp = "Java core";
            if (f["SQL Server"] == "true,false")
                temp += "SQL Server";
            if (f["PHP"] == "true,false")
                temp += "PHP";

            s.subjects = temp;

            s.username = f["username"];
            s.password = f["password"];
            s.comment = f["comment"];

            return View(s);
        }

        public ActionResult Bai2_Form()
        {
            return View();
        }
        public ActionResult Bai2_Detail(FormCollection f)
        {
            Student s = new Student();
            s.fname = f["fname"];
            s.lname = f["lname"];
            s.email = f["email"];
            s.password = f["password"];
            s.addr = f["addr"];
            s.gender = f["gender"];

            return View(s);
        }
    }
}