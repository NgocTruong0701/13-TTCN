using NhapDiemThi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhapDiemThi.Controllers
{
    public class NhapDiemThiController : Controller
    {
        // GET: NhapDiemThi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tinh(Student sv) 
        {
            ViewBag.Name = sv.Name;
            double TongDiem = sv.DiemToan + sv.DiemLy + sv.DiemHoa;
            int KhuVuc = sv.KhuVuc;
            int Option = sv.option;
            switch(KhuVuc) 
            {
                case 1:
                    TongDiem += 1;
                    break;
                case 2:
                    TongDiem += 2;
                    break;
                case 3:
                    TongDiem += 3;
                    break;  
            }
            if(Option==1)
            {
                TongDiem += 1;
            }
            string ketqua;
            if(TongDiem >= 20)
            {
                ketqua = "Do dai hoc";
            }
            else if(TongDiem >= 15 && TongDiem < 20)
            {
                ketqua = "Do cao dang";
            }
            else if (TongDiem >= 10 && TongDiem < 15)
            {
                ketqua = "Do trung cap";
            }
            else
            {
                ketqua = "Thi truot";
            }
            ViewBag.TongDiem = TongDiem;
            ViewBag.ketqua = ketqua;
            return View();
        }
    }
}