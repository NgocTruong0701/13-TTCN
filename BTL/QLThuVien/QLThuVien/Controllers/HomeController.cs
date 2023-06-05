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

        // GET: Home
        public ActionResult LoginAdmin()
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
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác.";
                }
            }
            else
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin.";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(FormCollection form)
        {
            string taiKhoan = form["taiKhoan"];
            string matKhau = form["matKhau"];

            if (!string.IsNullOrEmpty(taiKhoan) && !string.IsNullOrEmpty(matKhau))
            {
                var quantrivien = db.QUANTRIVIENs.FirstOrDefault(n => n.taiKhoan.Equals(taiKhoan) && n.matKhau.Equals(matKhau));
                if (quantrivien != null)
                {
                    // Lưu thông tin người dùng vào Session
                    Session["CurrentUser"] = quantrivien;
                    // Đăng nhập thành công, thực hiện các hành động khác
                    return RedirectToAction("Index", "Sach");
                }
                else
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác.";
                }
            }
            else
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin.";
            }

            return View();
        }



        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult LogoutAdmin()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("LoginAdmin");
        }

        public ActionResult Register()
        {
            NGUOIMUON NguoiMuon = new NGUOIMUON();
            int count = db.NGUOIMUONs.Count() + 1;
            NguoiMuon.maNguoiMuon = "MN0" + count;
            NguoiMuon.diaChi = "";
            NguoiMuon.matKhau = "";
            NguoiMuon.soDT = "";
            NguoiMuon.taiKhoan = "";
            NguoiMuon.tenNguoiMuon = "";
            
            return View(NguoiMuon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "maNguoiMuon,tenNguoiMuon,soDT,diaChi,taiKhoan,matKhau")] NGUOIMUON nGUOIMUON)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userExists = db.NGUOIMUONs.SingleOrDefault(n => n.taiKhoan.Equals(nGUOIMUON.taiKhoan));
                    if (userExists != null)
                    {
                        ViewBag.Error = "Tài khoản đã tồn tại, vui lòng nhập lại";
                        return View(nGUOIMUON);
                    }
                    else
                    {
                        db.NGUOIMUONs.Add(nGUOIMUON);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi: " + ex.Message;
                return View(nGUOIMUON);
            }
        }

    }
}