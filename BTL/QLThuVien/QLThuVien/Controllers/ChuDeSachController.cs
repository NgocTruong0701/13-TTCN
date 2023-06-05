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
    public class ChuDeSachController : Controller
    {
        private Model1 db = new Model1();

        // GET: ChuDeSach
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as QUANTRIVIEN;
            if (currentUser != null)
            {
                return View(db.CHUDESACHes.ToList());
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("LoginAdmin", "Home");
            }

            
        }

        public ActionResult Index2()
        {
            return PartialView(db.CHUDESACHes.ToList());
        }

        // GET: ChuDeSach/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDESACH cHUDESACH = db.CHUDESACHes.Find(id);
            if (cHUDESACH == null)
            {
                return HttpNotFound();
            }
            return View(cHUDESACH);
        }

        // GET: ChuDeSach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChuDeSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maChuDe,tenChuDe")] CHUDESACH cHUDESACH)
        {
            if (ModelState.IsValid)
            {
                cHUDESACH.tongLuongSach = 0;
                db.CHUDESACHes.Add(cHUDESACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUDESACH);
        }

        // GET: ChuDeSach/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDESACH cHUDESACH = db.CHUDESACHes.Find(id);
            if (cHUDESACH == null)
            {
                return HttpNotFound();
            }
            return View(cHUDESACH);
        }

        // POST: ChuDeSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maChuDe,tenChuDe")] CHUDESACH cHUDESACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUDESACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUDESACH);
        }

        // GET: ChuDeSach/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDESACH cHUDESACH = db.CHUDESACHes.Find(id);
            if (cHUDESACH == null)
            {
                return HttpNotFound();
            }
            return View(cHUDESACH);
        }

        // POST: ChuDeSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUDESACH cHUDESACH = db.CHUDESACHes.Find(id);
            try
            {
                db.CHUDESACHes.Remove(cHUDESACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi xóa dữ liệu!!" + ex.Message;
                return View(cHUDESACH);
            }
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
