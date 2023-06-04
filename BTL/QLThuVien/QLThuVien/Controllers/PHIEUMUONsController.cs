using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class PHIEUMUONsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PHIEUMUONs
        public ActionResult Index()
        {
            var pHIEUMUONs = db.PHIEUMUONs.Include(p => p.NGUOIMUON);
            return View(pHIEUMUONs.ToList());
        }

        public ActionResult IndexUser()
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                var pHIEUMUONs = db.PHIEUMUONs.Include(p => p.NGUOIMUON).Include(p => p.SACH);
                pHIEUMUONs = pHIEUMUONs.Where(p => p.maNguoiMuon.Equals(currentUser.maNguoiMuon));

                var phieuMuonModels = pHIEUMUONs.Select(p => new PhieuMuonViewModel
                {
                    maPhieuMuon = p.maPhieuMuon,
                    TenSach = db.SACHes.Where(s => s.maSach.Equals(p.maSach)).FirstOrDefault() != null ? db.SACHes.Where(s => s.maSach.Equals(p.maSach)).FirstOrDefault().tenSach : null,
                    NgayMuon = p.ngayMuon,
                    LoaiMuon = p.loaiMuon,
                    TienTheCho = p.tienTheCho,
                    NgayTra = p.ngayTra
                }).ToList();
                return View(phieuMuonModels);
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        [Route("thuvien/muonsach/{maSach?}")]
        public ActionResult MuonSach(string maSach)
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                // Thực hiện các hành động với thông tin người dùng
                PHIEUMUON phieumuon = new PHIEUMUON();
                SACH sach = db.SACHes.SingleOrDefault(s => s.maSach.Equals(maSach));
                var dbPT = db.PHIEUTRAs.Select(p => p);
                int countPhieuMuon = dbPT.Count();
                phieumuon.maPhieuMuon = "PM" + (countPhieuMuon + 1);
                phieumuon.maSach = maSach;
                phieumuon.tienTheCho = sach.giaSach;
                phieumuon.maNguoiMuon = currentUser.maNguoiMuon;
                phieumuon.loaiMuon = "";
                phieumuon.ngayMuon = DateTime.Now;
                phieumuon.ngayTra = DateTime.Now;
                ViewBag.tenSach = sach.tenSach;
                ViewBag.tenNguoiMuon = currentUser.tenNguoiMuon;
                return View(phieumuon);
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [Route("thuvien/muonsach/{maSach?}")]
        [ValidateAntiForgeryToken]
        public ActionResult MuonSach(FormCollection form)
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                PHIEUMUON phieumuon = new PHIEUMUON();
                try
                {
                    // Lấy dữ liệu từ FormCollection
                    phieumuon.maPhieuMuon = form["maPhieuMuon"];
                    phieumuon.ngayMuon = DateTime.Parse(form["ngayMuon"]);
                    phieumuon.ngayTra = DateTime.Parse(form["ngayTra"]);
                    phieumuon.loaiMuon = form["loaiMuon"];
                    phieumuon.tienTheCho = Decimal.Parse(form["tienTheCho"]);
                    phieumuon.maNguoiMuon = currentUser.maNguoiMuon;
                    string tenSach = form["tenSach"];

                    SACH Sach = db.SACHes.SingleOrDefault(s => s.tenSach.Equals(tenSach));
                    phieumuon.maSach = Sach.maSach;
                    Sach.soBanLuu -= 1;

                    
                    

                    db.PHIEUMUONs.Add(phieumuon);
                    db.SaveChanges();
                    db.Entry(Sach).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("IndexUser", "PHIEUMUONs");
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    ViewBag.Error = "Có lỗi: " + exceptionMessage;
                    return View(phieumuon);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Có lỗi: " + ex.ToString();
                    return View(phieumuon);
                }
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }


        // GET: PHIEUMUONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Create
        public ActionResult Create()
        {
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon");
            return View();
        }

        // POST: PHIEUMUONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhieuMuon,ngayMuon,loaiMuon,tienTheCho,ngayTra,maSach,maNguoiMuon")] PHIEUMUON pHIEUMUON)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUMUONs.Add(pHIEUMUON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUMUON.maNguoiMuon);
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUMUON.maNguoiMuon);
            return View(pHIEUMUON);
        }

        // POST: PHIEUMUONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhieuMuon,ngayMuon,loaiMuon,tienTheCho,ngayTra,maSach,maNguoiMuon")] PHIEUMUON pHIEUMUON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUMUON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUMUON.maNguoiMuon);
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUON);
        }

        // POST: PHIEUMUONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            db.PHIEUMUONs.Remove(pHIEUMUON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
