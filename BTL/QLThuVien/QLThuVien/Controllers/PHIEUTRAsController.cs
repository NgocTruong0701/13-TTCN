using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class PHIEUTRAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PHIEUTRAs
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as QUANTRIVIEN;
            if (currentUser != null)
            {
                var pHIEUTRAs = db.PHIEUTRAs.Include(p => p.NGUOIMUON);
                return View(pHIEUTRAs.ToList());
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("LoginAdmin", "Home");
            }
        }

        public ActionResult IndexUser()
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                var pHIEUTRAs = db.PHIEUTRAs.Include(p => p.NGUOIMUON);
                pHIEUTRAs = pHIEUTRAs.Where(p => p.maNguoiMuon.Equals(currentUser.maNguoiMuon));

                return View(pHIEUTRAs);
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        [Route("thuvien/trasach/{maPhieuMuon?}")]
        public ActionResult TraSach(string maPhieuMuon)
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                // Thực hiện các hành động với thông tin người dùng
                PHIEUTRA phieutra = new PHIEUTRA();
                PHIEUMUON phieumuon = db.PHIEUMUONs.SingleOrDefault(p => p.maPhieuMuon.Equals(maPhieuMuon));
                var dbPhieuTra = db.PHIEUTRAs.Select(p => p);
                int countPhieuTra = dbPhieuTra.Count();
                phieutra.maPhieuTra = "PT" + (countPhieuTra + 1);
                phieutra.maPhieuMuon = maPhieuMuon;
                phieutra.ngayTra = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan soNgayChenhLech = phieutra.ngayTra - phieumuon.ngayTra;
                int soNgay = soNgayChenhLech.Days;
                if (soNgay <= 0)
                {
                    phieutra.tienPhat = 0;
                    phieutra.tienHoanTra = phieumuon.tienTheCho;
                }
                else
                {
                    phieutra.tienPhat = (phieumuon.tienTheCho * 10 / 100);
                    phieutra.tienHoanTra = phieumuon.tienTheCho - phieutra.tienPhat;
                }
                phieutra.maNguoiMuon = currentUser.maNguoiMuon;
                ViewBag.NguoiMuon = currentUser.tenNguoiMuon;
                ViewBag.PhieuTra = phieutra;
                return View();
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [Route("thuvien/trasach/{maPhieuMuon?}")]
        [ValidateAntiForgeryToken]
        public ActionResult TraSach(FormCollection form)
        {
            var currentUser = Session["CurrentUser"] as NGUOIMUON;
            if (currentUser != null)
            {
                try
                {
                    string maPhieuMuon = form["maPhieuMuon"];

                    // Lấy phiếu mượn
                    var phieuMuon = db.PHIEUMUONs.SingleOrDefault(pm => pm.maPhieuMuon == maPhieuMuon);

                    if (phieuMuon != null)
                    {
                        var sach = db.SACHes.SingleOrDefault(s => s.maSach == phieuMuon.maSach);
                        if (sach != null)
                        {
                            sach.soBanLuu += 1;
                        }

                        // Xóa phiếu mượn
                        db.PHIEUMUONs.Remove(phieuMuon);
                        db.SaveChanges();
                    }

                    // Thêm phiếu trả
                    PHIEUTRA phieuTra = new PHIEUTRA
                    {
                        maPhieuTra = form["maPhieuTra"],
                        maPhieuMuon = maPhieuMuon,
                        ngayTra = DateTime.Now,
                        tienPhat = Decimal.Parse(form["tienPhat"]),
                        tienHoanTra = Decimal.Parse(form["tienHoanTra"]),
                        maNguoiMuon = form["maNguoiMuon"]
                    };

                    db.PHIEUTRAs.Add(phieuTra);
                    db.SaveChanges();

                    return RedirectToAction("IndexUser", "PHIEUTRAs");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Có lỗi: " + ex.ToString();
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Home");
            }
        }


        // GET: PHIEUTRAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Create
        public ActionResult Create()
        {
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon");
            return View();
        }

        // POST: PHIEUTRAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhieuTra,ngayTra,tienHoanTra,tienPhat,maNguoiMuon")] PHIEUTRA pHIEUTRA)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTRAs.Add(pHIEUTRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUTRA.maNguoiMuon);
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUTRA.maNguoiMuon);
            return View(pHIEUTRA);
        }

        // POST: PHIEUTRAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhieuTra,ngayTra,tienHoanTra,tienPhat,maNguoiMuon")] PHIEUTRA pHIEUTRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNguoiMuon = new SelectList(db.NGUOIMUONs, "maNguoiMuon", "tenNguoiMuon", pHIEUTRA.maNguoiMuon);
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTRA);
        }

        // POST: PHIEUTRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            db.PHIEUTRAs.Remove(pHIEUTRA);
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
