using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhTienDien.Models;

namespace TinhTienDien.Controllers
{
    public class TinhTienDienController : Controller
    {
        // GET: TinhTienDien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tinh(Person p) 
        {
            ViewBag.Name = p.Name;
            double SoDien = p.ChiSoMoi - p.ChiSoCu;
            ViewBag.SoDien = SoDien;
            int loaidien = p.LoaiDien;
            int option = p.Option;
            double ketqua = 0;
            if(SoDien <= 100)
            {
                ketqua = SoDien*2000;
            }    
            else if(SoDien > 100 && SoDien <=150)
            {
                ketqua = 100 * 2000 + (SoDien - 100) * 2500;
            }
            else if(SoDien > 150 && SoDien <= 200)
            {
                ketqua = 100 * 2000 + 50*2500 + (SoDien - 150) * 3000;
            }
            else
            {
                ketqua = 100 * 2000 + 50 * 2500 + 50 * 3000 + (SoDien - 200) * 4000;
            }
            if(loaidien == 2)
            {
                ketqua += ketqua * 0.2;
            }    
            else if(loaidien==3)
            {
                ketqua += ketqua * 0.3;
            }
            if(option == 1)

            {
                ketqua -= ketqua * 0.1;
            }
            ViewBag.SoTienTra = ketqua;
            return View();
        }
    }
}