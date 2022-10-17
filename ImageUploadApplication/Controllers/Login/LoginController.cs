using ImageUploadApplication.Helper;
using ImageUploadApplication.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadApplication.Controllers.Login
{
    public class LoginController : Controller
    {
        LoginModel _model = new LoginModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Login(FormCollection frm)
        {
            string email = frm["email"];
            string password = frm["password"];
            string status = _model.Authentication(email, password);
            if (status == "0")
            {
                TempData["AuthenticationError"] = "Invalid Email Or Password";
                return RedirectToAction("index");
            }
            else
            {
                Session["email"] = email;
                return RedirectToAction("AddImagesForm" , "AddImages");
            }
        }
    }
}