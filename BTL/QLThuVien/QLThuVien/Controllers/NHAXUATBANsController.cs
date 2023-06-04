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
    public class NHAXUATBANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: NHAXUATBANs
        public ActionResult Index()
        {
            return View(db.NHAXUATBANs.ToList());
        }

        // GET: NHAXUATBANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            if (nHAXUATBAN == null)
            {
                return HttpNotFound();
            }
            return View(nHAXUATBAN);
        }

        // GET: NHAXUATBANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHAXUATBANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNXB,tenNXB,soDT,diaChi")] NHAXUATBAN nHAXUATBAN)
        {
            if (ModelState.IsValid)
            {
                db.NHAXUATBANs.Add(nHAXUATBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHAXUATBAN);
        }

        // GET: NHAXUATBANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            if (nHAXUATBAN == null)
            {
                return HttpNotFound();
            }
            return View(nHAXUATBAN);
        }

        // POST: NHAXUATBANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNXB,tenNXB,soDT,diaChi")] NHAXUATBAN nHAXUATBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHAXUATBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHAXUATBAN);
        }

        // GET: NHAXUATBANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            if (nHAXUATBAN == null)
            {
                return HttpNotFound();
            }
            return View(nHAXUATBAN);
        }

        // POST: NHAXUATBANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHAXUATBAN nHAXUATBAN = db.NHAXUATBANs.Find(id);
            db.NHAXUATBANs.Remove(nHAXUATBAN);
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
