using HB8.CSMS.MVC.Models.UploadImage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace HB8.CSMS.MVC.Controllers
{
    public class UploadController : Controller
    {
        public ContentResult UploadImage()
        {

            var imageName = new List<UploadImageModel>();
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                string savedFileName = Path.Combine(Server.MapPath("~/ImagesTemp"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                if (hpf.ContentLength == 0)
                {
                    continue;
                }
                imageName.Add(new UploadImageModel()
                {
                    ImageName = hpf.FileName
                });
            }

            return Content("{\"name\":\"" + imageName[0].ImageName + "\"}", "application/json");
        }
        public string SaveImage()
        {
            HttpPostedFileBase photo = Request.Files["photo"];
            if (photo != null && photo.ContentLength > 0)
            {
                string extension = Path.GetExtension(photo.FileName);
                var fileName = System.Guid.NewGuid().ToString("N") + extension;
                var path = HostingEnvironment.MapPath("~/Images/");
                photo.SaveAs(Path.Combine(path, fileName));
                return fileName;
            }
            return null;
        }


    }
}
