using HB8.CSMS.BLL.Abstract;
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
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.MVC.Models.Paging;

namespace HB8.CSMS.MVC.Controllers
{

    public class StaffManagerController : Controller
    {
        #region  Khai bao
        public const int pageSize = 2;//So nhan vien duoc hien thi tren mot trang
        private IStaffManagerService staffService;
        public StaffManagerController(IStaffManagerService staffService)
        {
            this.staffService = staffService;
        }
        #endregion

        #region Code show danh sach nhan vien dang GRID VIEW
        /// <summary>
        /// Hien thi danh sach nhan vien dang GRID VIEW 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ListStaff(int? id)
        {
            var staff = new PagedData<StaffModel>();
            var page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("LargeStaffPartialView", GetPaginatedStaffs(page));//Tra ve VIEW dang GRID 
            }
            var model = staffService.GetListStaff();
            int count = model.Count();
            var listOfStaff = (from a in model
                                  select new StaffModel
                                  {
                                      ID = a.StaffID,
                                      StaffName = a.StaffName,
                                      NumberPhone = a.NumberPhone,
                                      Address = a.Address
                                  }).ToList();
            staff.Data = listOfStaff.Take(pageSize);
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.CurrentPage = 1;
            staff.Count = count;
            staff.PageSize = pageSize;
            return View("ListStaff", staff);
        }
        /// <summary>
        /// Nhan ve danh sach thong tin STAFF de hien thi
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private PagedData<StaffModel> GetPaginatedStaffs(int page)
        {
            var staff = new PagedData<StaffModel>();
            var skipRecords = page * pageSize;
            var model = staffService.GetListStaff();
            int count = model.Count();
            var listOfStaff = (from a in model
                                  select new StaffModel
                                  {
                                      ID = a.StaffID,
                                      StaffName = a.StaffName,   
                                      Image =a.Image,
                                      Address =a.Address,
                                      NumberPhone =a.NumberPhone,
                                      Email =a.Email
                                  }).OrderBy(x=>x.StaffName).Skip(skipRecords).Take(pageSize).ToList();
            staff.Data = listOfStaff;
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.Count = count;
            staff.PageSize = pageSize;
            staff.CurrentPage = page+1;
            return staff;
        }
        /// <summary>
        /// Hien thi danh sach nhan vien dang LIST VIEW
        /// </summary>
        /// <returns></returns>
        public ActionResult ListStaffView(int? page)
        {
            var pageNumber =0;
            if (page==null)
            {
                 pageNumber = page ?? 0;
            }
            else
            {
                 pageNumber =(int)page - 1;
            }
            return View("ListStaffPartialView", GetPaginatedStaffs(pageNumber));
        }
        #endregion

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
        /// Kiem tra ma nv co ton tai hay khong 
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns>Tra ve mot json mang gia tri true khi ma nv ton tai, nguoc lai false </returns>
        [HttpGet]
        public JsonResult HaveStaffId(string staffId)
        {
            var model = staffService.GetStaffById(staffId);
            bool data = false;
            if (model != null)
            {
                data = true;
            }
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
            return View();
        }

        /// <summary>
        /// Lay ve danh sach nhan vien
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StaffModel> ListAllStaff()
        {
            var list = staffService.GetListStaff();
            var model = (from item in list
                         select new StaffModel
                         {
                             ID = item.StaffID,
                             StaffName = item.StaffName,
                             Image = item.Image,
                             Address = item.Address,
                             NumberPhone = item.NumberPhone,
                             Email = item.Email,
                             UserName = item.User.UserName,
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
        public void EditStaff(StaffModel staff)
        {
            var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email);
            staffService.UpdateStaff(model);
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
            model.NumberPhone = item.NumberPhone;
            return model;
        }
        /// <summary>
        /// Goi form sua thong tin nhan vien
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStaffPV(string id)
        {
            var model = GetStaffByStaffId(id);
            return PartialView("EditStaffPartialView", model);
        }
        /// <summary>
        /// Goi form  them nhan vien
        /// </summary>
        /// <returns></returns>

        public ActionResult CreateStaffPV()
        {
            return PartialView("CreateStaffPartialView");
        }
        /// <summary>
        /// Luu thong tin nhan vien
        /// </summary>
        /// <param name="staff"></param>
        public void CreateStaff(StaffModel staff)
        {
            var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email);
            staffService.CreateStaff(model);
        }
        public void DeleteStaff(string id)
        {
            staffService.DeleteStaff(id);
        }

    }
}
