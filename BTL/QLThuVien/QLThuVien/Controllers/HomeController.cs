using System;
using System.Collections.Generic;
using System.Linq;
using QLThuVien.Models;
using System.Web;
using System.Web.Mvc;

namespace QLThuVien.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            string taiKhoan = form["taiKhoan"];
            string matKhau = form["matKhau"];

            if (!string.IsNullOrEmpty(taiKhoan) && !string.IsNullOrEmpty(matKhau))
            {
                var nguoiMuon = db.NGUOIMUONs.FirstOrDefault(n => n.taiKhoan.Equals(taiKhoan) && n.matKhau.Equals(matKhau));
                if (nguoiMuon != null)
                {
                    // Lưu thông tin người dùng vào Session
                    Session["CurrentUser"] = nguoiMuon;
                    // Đăng nhập thành công, thực hiện các hành động khác
                    return RedirectToAction("IndexUser", "Sach");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin.");
            }

            return View();
        }

    }
}