using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ModelEF.Model;

namespace WebShop.Areas.Admin.Controllers
{
    public class NguoiDungsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/NguoiDungs
        public ActionResult Index(string searchString, int? page)
        {
            ViewBag.searchString = searchString;
            var sanPham = db.NguoiDungs.Where(x => x.Username.Contains(searchString) || searchString == null).ToList().ToPagedList(page ?? 1, 5);
            return View(sanPham);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenNV,Email,DiaChi,SoDienThoai,Quyen,Username,Password,status")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenNV,Email,DiaChi,SoDienThoai,Quyen,Username,Password,status")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Delete/5
 

        public ActionResult Delete(string id)
        {
                NguoiDung nguoiDung = db.NguoiDungs.Find(id);
                db.NguoiDungs.Remove(nguoiDung);
                db.SaveChanges();
                 return Redirect("~/Admin/Nguoidungs/Index");

        }

        // POST: Admin/NguoiDungs/Delete/5


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
