using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;
using PagedList;

namespace QLThuVien.Controllers
{
    public class SachController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sach
        public ActionResult Index(int? page)
        {
            var currentUser = Session["CurrentUser"] as QUANTRIVIEN;
            if (currentUser != null)
            {
                var sACHes = db.SACHes.Include(s => s.CHUDESACH).Include(s => s.NHAXUATBAN).Include(s => s.TACGIA);

                // sap xep sach truoc khi phan trang
                sACHes = sACHes.OrderBy(s => s.maSach);
                int pageSize = 3; // bao nhieu 1 trang
                int pageNumber = (page ?? 1); // bien kiem soat trang hien tai
                return View(sACHes.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.Error = "Vui lòng đăng nhập";
                return RedirectToAction("LoginAdmin", "Home");
            }

                
        }

        // GET: Sach for User
        public ActionResult IndexUser(int? page, string search, string currentFilter)
        {
            var sACHes = db.SACHes.Include(s => s.CHUDESACH).Include(s => s.NHAXUATBAN).Include(s => s.TACGIA);

            // lay gia tri cua bo loc du lieu hien tai
            if (search != null)
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
                sACHes = sACHes.Where(p => p.tenSach.Contains(search));
            }

            // sap xep sach truoc khi phan trang
            sACHes = sACHes.OrderBy(s => s.maSach);
            int pageSize = 3; // bao nhieu 1 trang
            int pageNumber = (page ?? 1); // bien kiem soat trang hien tai
            return View(sACHes.ToPagedList(pageNumber, pageSize));
        }

        // Tac gia id
        [Route("thuvien/tacgia/{maTacGia?}")]
        public ActionResult BookBymaTacGia(string maTacGia)
        {
            ViewBag.TenTacGia = db.TACGIAs.SingleOrDefault(tg => tg.maTacGia.Equals(maTacGia)).tenTacGia;
            return View(db.SACHes.Where(s => s.maTacGia.Equals(maTacGia)).ToList());
        }

        // Chu de id
        [Route("thuvien/chudesach/{maChuDe?}")]
        public ActionResult BookBymaChuDe(string maChuDe)
        {
            ViewBag.TenChuDe = db.CHUDESACHes.SingleOrDefault(tg => tg.maChuDe.Equals(maChuDe)).tenChuDe;
            return View(db.SACHes.Where(s => s.maChuDe.Equals(maChuDe)).ToList());
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

        // GET: Sach/Details/5
        public ActionResult DetailsUser(string id)
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
        public ActionResult Create([Bind(Include = "maSach,tenSach,namXB,anhBia,moTa,giaSach,soTrang,tinhTrang,ngonNgu,maTacGia,maChuDe,maNXB")] SACH sACH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sACH.anhBia = "";
                    var f = Request.Files["ImageFile"];

                    if (f != null && f.ContentLength > 0)
                    {
                        // use Namespace called : System.IO
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        // lay ten file upload 
                        string uploadPath = Server.MapPath("~/Images/SACH/" + fileName);
                        // Copy va luu vao server
                        f.SaveAs(uploadPath);
                        // luu ten file vao truong anh bia
                        sACH.anhBia = fileName;
                    }
                    if (sACH.soBanLuu > 0)
                    {
                        sACH.tinhTrang = "Còn hàng";
                    }
                    else
                    {
                        sACH.tinhTrang = "Hết hàng";
                    }
                    db.SACHes.Add(sACH);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu: " + ex.Message;
                ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe", sACH.maChuDe);
                ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB", sACH.maNXB);
                ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia", sACH.maTacGia);
                return View(sACH);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew()
        {
            try
            {
                SACH sach = new SACH();
                sach.maSach = Request.Form["maSach"];
                sach.tenSach = Request.Form["tenSach"];
                sach.namXB = DateTime.Parse(Request.Form["namXB"]);
                sach.moTa = Request.Form["moTa"];
                sach.giaSach = Decimal.Parse(Request.Form["giaSach"]);
                sach.soBanLuu = Convert.ToInt32(Request.Form["soBanLuu"]);
                sach.soTrang = Convert.ToInt32(Request.Form["soTrang"]);
                sach.ngonNgu = Request.Form["ngonNgu"];
                sach.maTacGia = Request.Form["maTacGia"];
                sach.maChuDe = Request.Form["maChuDe"];
                sach.maNXB = Request.Form["maNXB"];

                sach.anhBia = "";
                var f = Request.Files["ImageFile"];

                if (f != null && f.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(f.FileName);
                    string uploadPath = Server.MapPath("~/Images/SACH/" + fileName);
                    f.SaveAs(uploadPath);
                    sach.anhBia = fileName;
                }

                if (sach.soBanLuu > 0)
                {
                    sach.tinhTrang = "Còn hàng";
                }
                else
                {
                    sach.tinhTrang = "Hết hàng";
                }

                if (ModelState.IsValid)
                {
                    db.SACHes.Add(sach);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu: " + ex.Message;
            }

            // Lấy dữ liệu cho dropdown list
            ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe");
            ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB");
            ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia");

            return View();
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
            try
            {
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    // Use the 'System.IO' namespace
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    // Get the uploaded file's name
                    string uploadPath = Server.MapPath("~/Images/SACH/" + fileName);
                    // Copy and save to the server
                    f.SaveAs(uploadPath);
                    // Save the file name to the 'anhBia' property
                    sACH.anhBia = fileName;
                }
                else
                {
                    // Retrieve the existing 'anhBia' value from the database
                    var existingSACH = db.SACHes.AsNoTracking().FirstOrDefault(s => s.maSach == sACH.maSach);
                    if (existingSACH != null)
                    {
                        sACH.anhBia = existingSACH.anhBia;
                    }
                }

                if (ModelState.IsValid)
                {
                    db.Entry(sACH).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu: " + ex.Message;
                ViewBag.maChuDe = new SelectList(db.CHUDESACHes, "maChuDe", "tenChuDe", sACH.maChuDe);
                ViewBag.maNXB = new SelectList(db.NHAXUATBANs, "maNXB", "tenNXB", sACH.maNXB);
                ViewBag.maTacGia = new SelectList(db.TACGIAs, "maTacGia", "tenTacGia", sACH.maTacGia);
                return View(sACH);
            }
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
            try
            {
                db.SACHes.Remove(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi xóa dữ liệu!!" + ex.Message;
                return View(sACH);
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
