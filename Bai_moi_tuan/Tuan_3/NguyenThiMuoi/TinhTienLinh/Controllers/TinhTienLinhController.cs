using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinhTienLinh.Controllers
{
    public class TinhTienLinhController : Controller
    {
        // GET: TinhTienLinh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tinh() 
        {
            string Id = Request["Id"];
            int BacLuong = Convert.ToInt32(Request["BacLuong"]);
            int ChucVu = Convert.ToInt32(Request["ChucVu"]);
            int NgayCong = Convert.ToInt32(Request["NgayCong"]);
            double TienLinh = BacLuong * 650000;

            double NCTL = NgayCong;

            if(NgayCong >= 25)
            {
                NCTL = (NgayCong - 25) * 2 + 25;
            }
            double PhuCap;
            if(ChucVu == 1) 
            {
                PhuCap = 500000;
            }else
            {
                PhuCap = 300000;
            }
            TienLinh = TienLinh * NCTL + PhuCap;

            ViewBag.Id = Id;
            ViewBag.NgayCong = NgayCong;
            ViewBag.TienLinh = TienLinh;
            return View();
        }
    }
}