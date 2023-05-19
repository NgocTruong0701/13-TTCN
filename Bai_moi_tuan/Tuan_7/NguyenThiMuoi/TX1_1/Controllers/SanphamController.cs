using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TX1_1.Models;

namespace TX1_1.Controllers
{
    public class SanphamController : Controller
    {
        public List<Sanpham> danhsach = new List<Sanpham>();
        public SanphamController()
        {
            danhsach.Add(new Sanpham("sp1", "Realme 3", 100, 200));
            danhsach.Add(new Sanpham("sp2", "Nokia 2660", 50, 150));
            danhsach.Add(new Sanpham("sp3", "Oppo Reno 4", 70, 160));
            danhsach.Add(new Sanpham("sp4", "Xiaomi Redmi", 50, 100));
            danhsach.Add(new Sanpham("sp5", "Realme 9i", 60, 300));
        }
        // GET: Sanpham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayProduct()
        {
            return View(danhsach);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult ShowInfor(Sanpham sp)
        {
            return View(sp);
        }
    }
}