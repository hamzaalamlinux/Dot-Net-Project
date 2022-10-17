using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadApplication.Controllers.Logout
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            Session["email"] = null;
            return RedirectToAction("Index" , "Login");
        }
    }
}