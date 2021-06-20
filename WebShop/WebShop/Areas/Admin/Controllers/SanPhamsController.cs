using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using PagedList;

namespace WebShop.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/SanPhams
        public ActionResult Index(string searchString, int? page)
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMuc).Where(x => x.TenSP.Contains(searchString) || searchString == null).
                OrderBy(s => s.SoLuong).ThenByDescending(s => s.DonGia).ToList().ToPagedList(page ?? 1, 5);
            return View(sanPhams);
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.DanhMuc_Id = new SelectList(db.DanhMucs, "DanhMuc_Id", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenSP,MoTa,DonGia,SoLuong,DanhMuc_Id")] SanPham sanPham, HttpPostedFileBase image)
        {

            if (image != null && image.ContentLength > 0)
            {
                string fileName = Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("/Image/" + fileName);
                image.SaveAs(urlImage);
                sanPham.HinhAnh = "/Image/" + fileName;
 
            }                       
            else
            {
                sanPham.HinhAnh = "https://annahemi.files.wordpress.com/2015/11/1274237_300x300.jpg";
            }
           
            if (ModelState.IsValid)
            {
                Random _r = new Random();
                char randomChar = (char)_r.Next('a', 'z');
                int num = _r.Next(10000);
                sanPham.id = "SP-" + num + randomChar;
                sanPham.status = true;
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DanhMuc_Id = new SelectList(db.DanhMucs, "DanhMuc_Id", "TenLoai", sanPham.DanhMuc_Id);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanhMuc_Id = new SelectList(db.DanhMucs, "DanhMuc_Id", "TenLoai", sanPham.DanhMuc_Id);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenSP,MoTa,DonGia,HinhAnh,SoLuong,DanhMuc_Id,status")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMuc_Id = new SelectList(db.DanhMucs, "DanhMuc_Id", "TenLoai", sanPham.DanhMuc_Id);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
