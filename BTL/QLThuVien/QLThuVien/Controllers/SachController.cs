using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class SachController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sach
        public ActionResult Index()
        {
            var sACHes = db.SACHes.Include(s => s.CHUDESACH).Include(s => s.NHAXUATBAN).Include(s => s.TACGIA);
            return View(sACHes.ToList());
        }

        // GET: Sach/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: Sach/Create
        public ActionResult Create()
        {
            ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe");
            ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB");
            ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia");
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSach,tenSach,namXB,anhBia,moTa,giaSach,soBanLuu,soTrang,tinhTrang,ngonNgu,maTacGia,maChuDe,maNXB")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe", sACH.maChuDe);
            ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB", sACH.maNXB);
            ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia", sACH.maTacGia);
            return View(sACH);
        }

        // GET: Sach/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe", sACH.maChuDe);
            ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB", sACH.maNXB);
            ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia", sACH.maTacGia);
            return View(sACH);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSach,tenSach,namXB,anhBia,moTa,giaSach,soBanLuu,soTrang,tinhTrang,ngonNgu,maTacGia,maChuDe,maNXB")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe", sACH.maChuDe);
            ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB", sACH.maNXB);
            ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia", sACH.maTacGia);
            return View(sACH);
        }

        // GET: Sach/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
