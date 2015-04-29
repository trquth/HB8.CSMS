using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.Models;
using HB8.CSMS.MVC.Models.Staff;
using HB8.CSMS.MVC.Models.UploadImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB8.CSMS.MVC.Controllers
{
    public class StaffManagerController : Controller
    {
        private IStaffManagerService<User> staffService;
        public StaffManagerController(IStaffManagerService<User> staffService)
        {
            this.staffService = staffService;
        }
        /// <summary>
        /// Trả về một danh sách các chức vụ
        /// </summary>
        /// <returns></returns>
        public JsonResult ListPosition()
        {
            var model = staffService.GetListPosition();
            var data = (from a in model
                        select new StaffModel
                        {
                            UserId = a.UserID,
                            UserName = a.UserName,
                        }).OrderBy(x => x.UserName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ViewResult CreateNewStaff()
        {
            return View();
        }
        [HttpPost]
        public ViewResult CreateNewStaff(StaffModel staff)
        {
            return View();
        }
        [HttpPost]
        public ContentResult UploadImage()
        {
            var imageName = new List<UploadImageModel>();
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
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


    }
}
