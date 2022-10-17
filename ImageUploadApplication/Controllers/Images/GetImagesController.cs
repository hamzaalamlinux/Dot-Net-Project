using ImageUploadApplication.Helper;
using ImageUploadApplication.Models;
using ImageUploadApplication.Models.Images;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadApplication.Controllers.Images
{
    public class GetImagesController : Controller
    {
        GetImagesModel _model = new GetImagesModel();
        // GET: GetImages
        [UserAuth]
        public ActionResult GetImages(int id)
        {
            if(id == null)
            {
                return RedirectToAction("Index" , "GetFolderImagesController");
            }
           var images =  GetImage(id);
            ViewBag.userid = id;
            return View(images);
        }

        public List<ImageModel> GetImage(int id)
        {
            List<ImageModel> images = new List<ImageModel>();
            DataTable dt = _model.GetImages(id);
            foreach (DataRow dr in dt.Rows)
            {
                images.Add(new ImageModel
                {
                    id = dr["id"].ToString(),
                    url = dr["url"].ToString()

                }); ;
            }
            return images.ToList();
        }
    }
}