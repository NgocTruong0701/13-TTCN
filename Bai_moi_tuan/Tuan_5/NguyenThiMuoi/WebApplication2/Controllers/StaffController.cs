using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            var fhinh = Request.Files["myfileImage"];
            var pathhinh = Server.MapPath("~/Images/" + fhinh.FileName);
            fhinh.SaveAs(pathhinh);
            string path = Server.MapPath("~/Staffinfo.txt");
            string[] info = { f["txtID"], f["txtName"], f["txtDate"], f["txtSalary"], fhinh.FileName };
            System.IO.File.WriteAllLines(path, info);
            return View("Index");            
        }

        public ActionResult Open()
        {
            string path = Server.MapPath("~/Staffinfo.txt");
            string[] info = System.IO.File.ReadAllLines(path);
            Staff s = new Staff();
            s.StaffID = int.Parse(info[0]);
            s.StaffName = info[1];
            s.BirthOfDate = DateTime.Parse(info[2]);
            s.Salary = decimal.Parse(info[3]);
            s.StaffImage = info[4];
            ViewBag.id = s.StaffID;
            ViewBag.name = s.StaffName;
            ViewBag.birthday = s.BirthOfDate.ToString("yyyy-MM-dd");
            ViewBag.salary = s.Salary;
            ViewBag.image = "../../Images/" + s.StaffImage;
            return View("Index");
        }
    }
}