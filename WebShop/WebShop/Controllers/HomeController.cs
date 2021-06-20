using ModelEF.Model;
using ModelEF.ModelDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var danhmucDAO = new DanhMucDAO();
            var sanphamDAO = new SanPhamDAO();
            ViewBag.ListSanPham = sanphamDAO.listSanPham();
            ViewBag.ListDanhMuc = danhmucDAO.listDanhMuc();
            return View();
        }
    }
}