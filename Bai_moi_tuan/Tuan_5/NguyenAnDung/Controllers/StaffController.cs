using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitaphuongdanbai5.Models;

namespace baitaphuongdanbai5.Controllers
{
    public class StaffController : Controller
    {
        // GET: StaffController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Save(FormCollection f)
        {
            var fhinh = Request.Files["myfileImage"];
            string _Filename = Path.GetFileName(fhinh.FileName);

            var pathhinh = Server.MapPath("~/Images/" + _Filename);
            fhinh.SaveAs(pathhinh);

            string path = Server.MapPath("~/Staffinfo.txt");
            string[] info = { f["txtID"], f["txtName"], f["txtDate"], f["txtSalary"], _Filename };
            System.IO.File.WriteAllLines(path, info);

            return View("Index");
        }

        public ActionResult Open()
        {
            string path = Server.MapPath("~/Staffinfo.txt");
            string[] info = System.IO.File.ReadAllLines(path);
            Staff s = new Staff();
            s.Staffid = int.Parse(info[0]);
            s.Staffname = info[1];
            s.birthofdate = DateTime.Parse(info[2]);
            s.salary = decimal.Parse(info[3]);
            s.Staffimage = info[4];

            ViewBag.id = s.Staffid;
            ViewBag.name = s.Staffname;
            ViewBag.birthday = s.birthofdate.ToString("yyyy-MM-dd");
            ViewBag.salary = s.salary;
            ViewBag.image = "../../Images/" + s.Staffimage;


            return View("Index");
        }
    }
}