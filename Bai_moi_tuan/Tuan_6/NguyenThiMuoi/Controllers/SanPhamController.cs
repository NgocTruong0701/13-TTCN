using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De5.Models;

namespace De5.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham()
        {
            List<SanPham> li = new List<SanPham>();
            li.Add(new SanPham("s01", "San pham 1", 10, 100, 0));
            li.Add(new SanPham("s02", "San pham 2", 20, 120, 0));
            li.Add(new SanPham("s03", "San pham 3", 15, 200, 0));
            li.Add(new SanPham("s04", "San pham 4", 30, 150, 0));
            li.Add(new SanPham("s04", "San pham 4", 20, 50, 0));
            return View(li);

        }
        public ActionResult HienThiDS()
        {
            int giatien = int.Parse(Request["giatien"]);
            if (giatien > 100)
            {
                List<SanPham> li1 = new List<SanPham>();
                li1.Add(new SanPham("s01", "San pham 1", 10, 100, 0));
                li1.Add(new SanPham("s02", "San pham 2", 20, 120, 0));
                li1.Add(new SanPham("s03", "San pham 3", 15, 200, 0));
                li1.Add(new SanPham("s04", "San pham 4", 30, 150, 0));
                li1.Add(new SanPham("s04", "San pham 4", 20, 50, 0));
            }

            int giamgia = int.Parse(Request["giamgia"]);
            if (giamgia == 1)
            {
                List<SanPham> li2 = new List<SanPham>();
                li2.Add(new SanPham("s01", "San pham 1", 10, 100, 0));
                li2.Add(new SanPham("s02", "San pham 2", 20, 120, 0));
                li2.Add(new SanPham("s03", "San pham 3", 15, 200, 0));
                li2.Add(new SanPham("s04", "San pham 4", 30, 150, 0));
                li2.Add(new SanPham("s04", "San pham 4", 20, 50, 0));
            }

            ViewBag.tien = giatien;
            ViewBag.giamgia = giamgia;
            return View();
            



        }

        public ActionResult NhapSP()
        {
            return View();
        }    

        public ActionResult HienThiSP(SanPham s)
        {
            return View(s);
        }


    }
}