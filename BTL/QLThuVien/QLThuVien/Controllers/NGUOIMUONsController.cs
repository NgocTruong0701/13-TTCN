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
    public class NGUOIMUONsController : Controller
    {
        private Model1 db = new Model1();

        // GET: NGUOIMUONs
        public ActionResult Index()
        {
            return View(db.NGUOIMUONs.ToList());
        }

        // GET: NGUOIMUONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIMUON nGUOIMUON = db.NGUOIMUONs.Find(id);
            if (nGUOIMUON == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIMUON);
        }

        // GET: NGUOIMUONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NGUOIMUONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNguoiMuon,tenNguoiMuon,soDT,diaChi,taiKhoan,matKhau")] NGUOIMUON nGUOIMUON)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NGUOIMUONs.Add(nGUOIMUON);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Có lỗi: " + ex.Message;
                return View(nGUOIMUON);
            }
        }

        // GET: NGUOIMUONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIMUON nGUOIMUON = db.NGUOIMUONs.Find(id);
            if (nGUOIMUON == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIMUON);
        }

        // POST: NGUOIMUONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNguoiMuon,tenNguoiMuon,soDT,diaChi,taiKhoan,matKhau")] NGUOIMUON nGUOIMUON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIMUON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUOIMUON);
        }

        // GET: NGUOIMUONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIMUON nGUOIMUON = db.NGUOIMUONs.Find(id);
            if (nGUOIMUON == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIMUON);
        }

        // POST: NGUOIMUONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NGUOIMUON nGUOIMUON = db.NGUOIMUONs.Find(id);
            db.NGUOIMUONs.Remove(nGUOIMUON);
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
