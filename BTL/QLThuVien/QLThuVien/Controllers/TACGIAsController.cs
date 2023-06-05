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
    public class TACGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TACGIAs
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"] as QUANTRIVIEN;
            if (currentUser != null)
            {
                return View(db.TACGIAs.ToList());
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("LoginAdmin", "Home");
            }
           
        }

        public ActionResult Index2()
        {
            return PartialView(db.TACGIAs.ToList());
        }

        // GET: TACGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // GET: TACGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TACGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maTacGia,tenTacGia,namSinh,moTa,anh")] TACGIA tACGIA)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tACGIA.anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        // use Namespace called : System.IO
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        // lay ten file upload 
                        string uploadPath = Server.MapPath("~/Images/TACGIA/" + fileName);
                        // Copy va luu vao server
                        f.SaveAs(uploadPath);
                        // luu ten file vao truong anh bia
                        tACGIA.anh = fileName;
                    }

                    db.TACGIAs.Add(tACGIA);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu: " + ex.Message;
                return View(tACGIA);
            }
        }

        // GET: TACGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: TACGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maTacGia,tenTacGia,namSinh,moTa,anh")] TACGIA tACGIA)
        {
            try
            {
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    // Use the 'System.IO' namespace
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    // Get the uploaded file's name
                    string uploadPath = Server.MapPath("~/Images/TACGIA/" + fileName);
                    // Copy and save to the server
                    f.SaveAs(uploadPath);
                    // Save the file name to the 'anhBia' property
                    tACGIA.anh = fileName;
                }
                else
                {
                    // Retrieve the existing 'anhBia' value from the database
                    var existingTacGia = db.TACGIAs.AsNoTracking().FirstOrDefault(s => s.maTacGia == tACGIA.maTacGia);
                    if (existingTacGia != null)
                    {
                        tACGIA.anh = existingTacGia.anh;
                    }
                }

                if (ModelState.IsValid)
                {
                    db.Entry(tACGIA).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu: " + ex.Message;
                return View(tACGIA);
            }
        }

        // GET: TACGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: TACGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TACGIA tACGIA = db.TACGIAs.Find(id);
            try
            {
                db.TACGIAs.Remove(tACGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi xóa dữ liệu!!" + ex.Message;
                return View(tACGIA);
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
