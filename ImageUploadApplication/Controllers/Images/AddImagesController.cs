using ImageUploadApplication.Helper;
using ImageUploadApplication.Models;
using ImageUploadApplication.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ImageUploadApplication.Controllers.AddImages
{
    public class AddImagesController : Controller
    {
        string base64String;
        AddImagesModel _model = new AddImagesModel();
        
        // GET: AddImages
        [UserAuth]
        public ActionResult AddImagesForm()
        {
            var users = GetUsers();
            return View(users);
        }

        [HttpPost]
        public JsonResult SaveImages(FormCollection frm)
        {
            var Images = frm["imgsrc"];
            var userid = frm["userid"];
            try
            {
                foreach (var item in Images.Split('|'))
                {
                    base64String = item;
                    _model.AddImages(base64String ,Convert.ToInt32(userid));
                }
                return Json(new { status = 200, message = "Success"});
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, message = ex.Message });
            }
        }

        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            DataTable dt = GetUsersModel.GetUser();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new Users
                {
                    id = dr["id"].ToString(),
                    username = dr["username"].ToString()

                }); ;
            }
            return users.ToList();
        }

    }

}