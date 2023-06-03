using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TX_2.Models;
using PagedList;

namespace TX_2.Controllers
{
    public class SanphamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sanphams
        public ActionResult Index(string search, string currentFilter, int? page)
        {
            // lay ra danh sach san pham
            var sanphams = db.Sanphams.Include(s => s.Danhmuc);

            // lay gia tri cua bo loc du lieu hien tai
            if(search != null)
            {
                page = 1; // trang dau
            }
            else
            {
                search = currentFilter;
            }
            ViewBag.CurrentFilter = search;

            // tim kiem san pham theo ten
            if (!String.IsNullOrEmpty(search))
            {
                try
                {
                    int money = int.Parse(search);
                    sanphams = sanphams.Where(p => p.Giatien == money);
                }
                catch(Exception ex)
                {
                    sanphams = sanphams.Where(p => p.Tenvd.Contains(search));
                }
            }

            // Sap xep san pham truoc khi phan trang
            sanphams = sanphams.OrderBy(p => p.Mavd);
            int pageSize = 3; //kich thuoc bao nhieu 1 trang
            int pageNumber = (page ?? 1); // bien kiem soat trang hien tai

            // lay ra danh sach san pham moi nhat
            ViewBag.dsSPNew = db.Sanphams.OrderByDescending(p => p.Mavd).Select(p => p).ToList();
            // return View(sanphams.ToList());

            // Dung thu vien PageList de phan trang
            return View(sanphams.ToPagedList(pageNumber, pageSize));
        }

        // Danh muc id 
        [Route("shop/danhmuc/{MaDanhmuc?}")]
        public ActionResult ProductByCategoryid(int MaDanhmuc)
        {
            ViewBag.TenDanhMuc = db.Danhmucs.SingleOrDefault(c => c.MaDanhmuc == MaDanhmuc).TenDanhmuc;
            return View(db.Sanphams.Where(p => p.MaDanhmuc == MaDanhmuc).ToList());
        }

        // GET: Sanphams/Details/5
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
            ViewBag.TenSP = sanpham.Tenvd;
            return View(sanpham);
        }

        // GET: Sanphams/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc");
            return View();
        }

        // POST: Sanphams/Create
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
                    if (f != null && f.ContentLength > 0)
                    {
                        // use Namespace called : System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        // lay ten file upload 
                        string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                        // Copy va luu vao server
                        f.SaveAs(UploadPath);
                        // luu ten file vao truong image
                        sanpham.TenAnh = FileName;
                    }
                    db.Sanphams.Add(sanpham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!!" + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }


        }

        // GET: Sanphams/Edit/5
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
            ViewBag.TenSP = sanpham.Tenvd;
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mavd,Tenvd,Mota,TenAnh,Giatien,Soluong,MaDanhmuc")] Sanpham sanpham)
        {

            try
            {
                var f = Request.Files["ImageFile"];
                if(f != null && f.ContentLength > 0)
                {
                    // use Namespace called : System.IO
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    // lay ten file upload 
                    string UploadPath = Server.MapPath("~/Content/Images/" + FileName);
                    // Copy va luu vao server
                    f.SaveAs(UploadPath);
                    // luu ten file vao truong image
                    sanpham.TenAnh = FileName;
                }
                if (ModelState.IsValid)
                {
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!!" + ex.Message;
                ViewBag.MaDanhmuc = new SelectList(db.Danhmucs, "MaDanhmuc", "TenDanhmuc", sanpham.MaDanhmuc);
                return View(sanpham);
            }
        }

        // GET: Sanphams/Delete/5
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

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            try
            {
                db.Sanphams.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi xóa dữ liệu!!" + ex.Message;
                return View(sanpham);
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
