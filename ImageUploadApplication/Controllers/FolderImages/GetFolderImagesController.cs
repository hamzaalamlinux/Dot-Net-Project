using ImageUploadApplication.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageUploadApplication.Models;
using ImageUploadApplication.Models.Images;

namespace ImageUploadApplication.Controllers
{
    public class GetFolderImagesController : Controller
    {
        string base64String;
        AddImagesModel _model = new AddImagesModel();
        // GET: TestGetImages
        public ActionResult Index()
        {
            var folders = GetFolders();
            return View(folders);
        }

        public List<Folders> GetFolders()
        {
            List<Folders> folders = new List<Folders>();
            DataTable dt = GetFolder.GetFolders();
            foreach (DataRow dr in dt.Rows)
            {
                folders.Add(new Folders
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    username = dr["username"].ToString()
                }); 
            }
            return folders.ToList();
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
                    _model.AddImages(base64String, Convert.ToInt32(userid));
                }
                return Json(new { status = 200, message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, message = ex.Message });
            }
        }
    }
}