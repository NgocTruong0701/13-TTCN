
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculate.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double a, double b, string PhepTinh = "+")
        {
            switch (PhepTinh)
            {
                case "+":
                    ViewBag.Ketqua = string.Format("{0:0.##} + {1:0.##} = {2:0.##}", a, b, (a+b));
                    break;
                case "-":
                    ViewBag.Ketqua = string.Format("{0:0.##} - {1:0.##} = {2:0.##}", a, b,( a - b));
                    break;
                case "*":
                    ViewBag.Ketqua = string.Format("{0:0.##} * {1:0.##} = {2:0.##}", a, b,( a * b));
                    break;
                case "/":
                    if (b == 0)
                    {
                        ViewBag.Ketqua = "Khong chia duoc cho 0";
                        break;
                    }
                    ViewBag.Ketqua = string.Format("{0:0.##} * {1:0.##} = {2:0.##}", a, b, (a / b));
                    break;
                default:
                    break;
            }
            return View("Index");
        }
        
        

    }
}