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
    public class QUANTRIVIENController : Controller
    {
        private Model1 db = new Model1();

        // GET: QUANTRIVIEN
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as QUANTRIVIEN;
            if (currentUser != null)
            {
                return View(db.QUANTRIVIENs.ToList());
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("LoginAdmin", "Home");
            }


        }

        // GET: QUANTRIVIEN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRIVIEN qUANTRIVIEN = db.QUANTRIVIENs.Find(id);
            if (qUANTRIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRIVIEN);
        }

        // GET: QUANTRIVIEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUANTRIVIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maQTV,tenQTV,taiKhoan,matKhau")] QUANTRIVIEN qUANTRIVIEN)
        {
            if (ModelState.IsValid)
            {
                db.QUANTRIVIENs.Add(qUANTRIVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANTRIVIEN);
        }

        // GET: QUANTRIVIEN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRIVIEN qUANTRIVIEN = db.QUANTRIVIENs.Find(id);
            if (qUANTRIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRIVIEN);
        }

        // POST: QUANTRIVIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maQTV,tenQTV,taiKhoan,matKhau")] QUANTRIVIEN qUANTRIVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANTRIVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANTRIVIEN);
        }

        // GET: QUANTRIVIEN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANTRIVIEN qUANTRIVIEN = db.QUANTRIVIENs.Find(id);
            if (qUANTRIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANTRIVIEN);
        }

        // POST: QUANTRIVIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANTRIVIEN qUANTRIVIEN = db.QUANTRIVIENs.Find(id);
            db.QUANTRIVIENs.Remove(qUANTRIVIEN);
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
