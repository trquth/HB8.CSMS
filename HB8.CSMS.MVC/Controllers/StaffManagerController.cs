using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.Models;
using HB8.CSMS.MVC.Models.Staff;
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
    public class StaffManagerController : Controller
    {
        private IStaffManagerService staffService;
        public StaffManagerController(IStaffManagerService staffService)
        {
            this.staffService = staffService;
        }
        /// <summary>
        /// Trả về một danh sách các chức vụ dang JSON
        /// </summary>
        /// <returns>JSON</returns>
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
        /// <summary>
        /// Trả về danh sách chức vụ 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StaffModel> GetListPosition()
        {
            var model = staffService.GetListPosition();
            var data = (from a in model
                        select new StaffModel
                        {
                            UserId = a.UserID,
                            UserName = a.UserName,
                        }).OrderBy(x => x.UserName);
            return data;
        }
        [HttpGet]
        public ViewResult CreateNewStaff()
        {
            ViewBag.Position = GetListPosition();
            return View();
        }
        [HttpPost]
        public ViewResult CreateNewStaff(StaffModel staff)
        {
            if (ModelState.IsValid)
            {
                
            }
            var newStaff = new Staff();
            newStaff.StaffID = staff.ID;
            newStaff.StaffName = staff.StaffName;
            newStaff.Email = staff.Email;
            newStaff.Address = staff.Address;
            newStaff.NumberPhone = staff.NumberPhone;
            newStaff.UserId = staff.UserId;           
            HttpPostedFileBase photo = Request.Files["fileupload"];
            if (photo != null && photo.ContentLength > 0)
            {
                string extension = Path.GetExtension(photo.FileName);
                var fileName = System.Guid.NewGuid().ToString("N") + extension;
                var path = HostingEnvironment.MapPath("~/Images/");
                photo.SaveAs(Path.Combine(path, fileName));
                newStaff.Image = fileName;
            }
            staffService.CreateStaff(newStaff);
            ViewBag.Position = GetListPosition();
            return View();
        }

    }
}
