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
        public ActionResult Login(NGUOIMUON model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tài khoản và mật khẩu

                var nguoiMuon = db.NGUOIMUONs.FirstOrDefault(n => n.taiKhoan == model.taiKhoan && n.matKhau == model.matKhau);
                if (nguoiMuon != null)
                {
                    // Đăng nhập thành công, thực hiện các hành động khác
                    return RedirectToAction("IndexUser", "Sach");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác.");
                }
            }
            return View(model);
        }
    }
}