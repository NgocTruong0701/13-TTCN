using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example_MVC_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public String NewView()
        {
            String maSV = "2020601391";
            String name = "Le Ngoc Truong";
            int age = 20;
            String date = "07/01/2002";
            String address = "Thanh Hoa";
            return "MaSV: " + maSV + " ten: " + name + " age: " + age + "Date: " + date + " address: " + address;
        }
    }
}