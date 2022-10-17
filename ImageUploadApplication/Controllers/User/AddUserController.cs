using ImageUploadApplication.Helper;
using ImageUploadApplication.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadApplication.Controllers.User
{
    public class AddUserController : Controller
    {
        // GET: AddUser
        UsersModel _model = new UsersModel();
        [UserAuth]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddUser(FormCollection frm)
        {
            var username = frm["username"];
            var email = frm["email"];
            var password = frm["password"];
            _model.AddUsers(username, email, password);
            return RedirectToAction("AddImagesForm", "AddImages");

        }
    }
}