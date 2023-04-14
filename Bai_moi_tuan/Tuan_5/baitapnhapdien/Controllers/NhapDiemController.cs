using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitaphuongdanbai5.Models;

namespace baitaphuongdanbai5.Controllers
{
    public class NhapDiemController : Controller
    {
        // GET: NhapDiem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(SinhVien sv)
        {
            //Đường dẫn tới file lưu dữ liệu
            string path = Server.MapPath("~/StudentInfor.txt");

            string[] lines = { sv.Id, sv.Name, sv.Mark.ToString() };

            System.IO.File.WriteAllLines(path, lines);
            ViewBag.Hanhdong = "Da ghi file";

            return View("Index");
        }

        public ActionResult Open(SinhVien sv)
        {
            string path = Server.MapPath("~/StudentInfor.txt");

            string[] lines = System.IO.File.ReadAllLines(path);

            sv.Id = lines[0];
            sv.Name = lines[1];
            sv.Mark = Convert.ToDouble(lines[2]);

            ViewBag.Thongtin = "Mã sinh viên: " + sv.Id + "\n" +  "Họ tên: " + sv.Name + "\n" + "Điểm: " + sv.Mark;
            ViewBag.Hanhdong = "Đã đọc được file";

            return View("Index");
        }
    }
}