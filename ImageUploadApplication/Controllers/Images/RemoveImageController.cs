using ImageUploadApplication.Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadApplication.Controllers.Images
{
    public class RemoveImageController : Controller
    {
        DeleteImageModel _model = new DeleteImageModel();

        // GET: RemoveImage
      
        public JsonResult Remove(int id)
        {
            try
            {
                _model.Remove(id);
                return Json(new { status = 200, message = "success" } , JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { status = 400, message = ex.Message} , JsonRequestBehavior.AllowGet);
            }
        }
    }
}