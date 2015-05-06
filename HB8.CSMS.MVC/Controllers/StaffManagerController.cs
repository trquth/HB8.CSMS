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
using PagedList;

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
        
        [HttpGet]
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
        /// Gan danh sach chuc vu cua nhan vien lay tu DATABASE vao MODEL
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
        public ViewResult ListStaff( int? page)
        {
            var model = ListAllStaff();
            int numberPage = page ?? 1;
            var onePageOfStaffs = model.ToPagedList(numberPage, 5);
            ViewBag.OnePageOfStaffs = onePageOfStaffs;
            return View();
        }
        public IEnumerable<StaffModel> ListAllStaff()
        {
            var list = staffService.GetListStaff();
            var model = (from item in list
                         select new StaffModel
                         {
                            ID = item.StaffID,
                            StaffName =item.StaffName,
                            Image =item.Image,
                            Address =item.Address,
                            NumberPhone = item.NumberPhone,
                            Email = item.Email,
                            UserName =item.User.UserName,
                         });
            return model;
        }
        public ViewResult EditStaff(string staffId)
        {
            var model = GetStaffByStaffId(staffId);
            ViewBag.Position = GetListPosition();
            return View(model);
        }
        [HttpPost]
        public void EditStaff(Staff model)
        {
            //if (ModelState.IsValid)
            //{
            //    return View();
            //}
            //return ;
        }
        /// <summary>
        /// Gan nhan vien co manv duoc chon tu DATABASE vao MODEL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffModel GetStaffByStaffId(string id)
        {
            var item = staffService.GetStaffById(id);
            var model = new StaffModel();
            model.ID = item.StaffID;
            model.Image = item.Image;
            model.ID = item.StaffID;
            model.StaffName = item.StaffName;
            model.UserName = item.User.UserName;
            model.Address = item.Address;
            model.Email = item.Email;
            return model;
        }
        [HttpGet]
        public ActionResult EditStaffPV(string id)
        {
            var model = GetStaffByStaffId(id);
            return PartialView("EditStaffPartialView", model);
        }
    }
}
