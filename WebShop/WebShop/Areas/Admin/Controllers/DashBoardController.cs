using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class DashBoardController : BaseController
    {
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            //if (Session["UserAdmin"].Equals(""))
            //{
            //    return Redirect("~/Admin/login");
            //}
            return View();
        }
    }
}