using CaculateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaculateProject.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double a, double b, string option = "+")
        {
            switch (option)
            {
                case "+":
                    ViewBag.Ketqua = a + b;
                    break;
                case "-":
                    ViewBag.Ketqua = a - b;
                    break;
                case "*":
                    ViewBag.Ketqua = a * b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        ViewBag.Ketqua = "Khong chia duoc cho 0";
                        break;
                    }
                    ViewBag.Ketqua = a / b;
                    break;
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult CalculatorInput()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculatorInput(Calculation c)
        {
            switch (c.option)
            {
                case "+":
                    ViewBag.Ketqua = c.num_one + c.num_two; 
                    break;
                case "-":
                    ViewBag.Ketqua = c.num_one - c.num_two;
                    break;
                case "*":
                    ViewBag.Ketqua = c.num_one * c.num_two;
                    break;
                case "/":
                    if(c.num_one == 0)
                    {
                        ViewBag.Ketqua = "Khong the chia cho 0";
                        break;
                    }
                    ViewBag.Ketqua = c.num_one / c.num_two;
                    break;
            }
            return View("CalculatorInput");
        }
    }
}