using ModelEF.ModelDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF   .Model;

namespace WebShop.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        NguoiDungDAO user_DAO = new NguoiDungDAO();

        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.StrError = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            var error = "";
            String user = filed["username"];
            String pass = filed["password"];
            NguoiDung user_row = user_DAO.getRow(user);
            if (user_row != null && user_row.Quyen == 1)
            {
                if (user_row.status == true)
                {
                        if (user_row.Password.Equals(pass)) {
                            Session["UserAdmin"] = user_row.TenNV;
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            error = "Mật khẩu không chính xác";
                        }                 
                }    
                    else             
                {
                    error = "Tài khoản bạn đã bị khóa";
                } 
            }
            else
            {
                error = "Tên đăng nhập không tồn tại";
            }
            ViewBag.StrError = "<div class='text-danger'>" + error + "</div>";
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            Session["UserId"] = "";
            return Redirect("~/Admin/login");
        }
    }
}