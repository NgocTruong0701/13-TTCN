using Read_and_Write_Infor_Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Read_and_Write_Infor_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            try
            {
                // Lay thong tin tu input type = file
                var fhinh = Request.Files["Image"];
                // Save hinh ve sever
                var pathhinh = Server.MapPath("~/Images/" + fhinh.FileName);
                fhinh.SaveAs(pathhinh);
                string path = Server.MapPath("~/EmployeeInfor.txt");
                string[] infor = { f["Id"], f["Name"], f["BirthOfDate"], f["Salary"], fhinh.FileName };
                // Ghi thong tin vao file
                System.IO.File.WriteAllLines(path, infor);
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        public ActionResult Open()
        {
            // Doc du lieu tu server
            string path = Server.MapPath("~/EmployeeInfor.txt");
            string[] infor = System.IO.File.ReadAllLines(path);
            Employee e = new Employee();
            e.Id = int.Parse(infor[0]);
            e.Name = infor[1];
            e.BirthOfDate = DateTime.Parse(infor[2]);
            e.Salary = Decimal.Parse(infor[3]);
            e.Image = infor[4];

            // Chuyen cac thong tin sang view thong qua ViewBag
            ViewBag.Id = e.Id;
            ViewBag.Name = e.Name;
            ViewBag.BirthOfDate = e.BirthOfDate.ToString("yyyy-MM-dd");
            ViewBag.Salary = e.Salary; 
            ViewBag.Image = "../../Images/" + e.Image;
            return View("Index");
        }
    }
}