using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnTap_1.Models;

namespace OnTap_1.Controllers
{
    public class ObjectsController : Controller
    {
        private CSDLModel db = new CSDLModel();

        // GET: Objects
        public ActionResult Index(string searchString)
        {
            var sanphams = db.Sanphams.Include(s => s.Danhmuc);
            if(!String.IsNullOrEmpty(searchString))
            {
                decimal gia = decimal.Parse(searchString);
                sanphams = sanphams.Where(s => s.Giatien >= gia);
            }
            return View(sanphams.ToList());
        }

        // GET: Objects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Objects/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mavd,Tenvd,Mota,TenAnh,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanpham.Mota = "";
                    var f = Request.Files["ImageFile"];
                    if(f!=null&&f.ContentLength>0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadFile = Server.MapPath("~/Images/" + FileName);
                        f.SaveAs(UploadFile);
                        sanpham.Mota = FileName;
                    }
                    db.Sanphams.Add(sanpham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Loi " + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }

        }
        public ActionResult ThemSamPham()
        {
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham([Bind(Include = "Mavd,Tenvd,Mota,TenAnh,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanpham.Mota = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadFile = Server.MapPath("~/Images/" + FileName);
                        f.SaveAs(UploadFile);
                        sanpham.Mota = FileName;
                    }
                    db.Sanphams.Add(sanpham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Loi " + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }

        }

        // GET: Objects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
            return View(sanpham);
        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mavd,Tenvd,Mota,TenAnh,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
            return View(sanpham);
        }

        // GET: Objects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            db.Sanphams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult XoaSanPham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("XoaSanPham")]
        [ValidateAntiForgeryToken]
        public ActionResult XoaSanPhamConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            try
            {
                db.Sanphams.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Looi " + ex.Message;
                return View("XoaSanPham", sanpham);
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
