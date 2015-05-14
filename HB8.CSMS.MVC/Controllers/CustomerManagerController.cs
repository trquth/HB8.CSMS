using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.MVC.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HB8.CSMS.MVC.Models.Paging;

namespace HB8.CSMS.MVC.Controllers
{
    public class CustomerManagerController : Controller
    {
        private ICustomerManagerService customerService;
        //const int recordsPerPage = 1;
        public const int pageSize = 2;
        public CustomerManagerController(ICustomerManagerService customerService)
        {
            this.customerService = customerService;
        }
        /// <summary>
        /// Trả về một danh sách các chức vụ dang JSON
        /// </summary>
        /// <returns>JSON</returns>

        [HttpGet]
        public JsonResult ListStatus()
        {
            var model = customerService.GetListStatus();
            var data = (from a in model
                        select new CustomerModel
                        {
                            StatusID = a.StatusId,
                            StatusName = a.StatusName,
                        }).OrderBy(x => x.StatusName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Kiem tra ma nv co ton tai hay khong 
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns>Tra ve mot json mang gia tri true khi ma nv ton tai, nguoc lai false </returns>
        //[HttpGet]
        //public JsonResult HaveStaffId(string staffId)
        //{
        //    var model = staffService.GetStaffById(staffId);
        //    bool data = false;
        //    if (model != null)
        //    {
        //        data = true;
        //    }
        //    return Json(data, JsonRequestBehavior.AllowGet);

        //}
        ///// <summary>
        ///// Gan danh sach chuc vu cua nhan vien lay tu DATABASE vao MODEL
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<StaffModel> GetListPosition()
        //{
        //    var model = staffService.GetListPosition();
        //    var data = (from a in model
        //                select new StaffModel
        //                {
        //                    UserId = a.UserID,
        //                    UserName = a.UserName,
        //                }).OrderBy(x => x.UserName);
        //    return data;
        //}
        //[HttpGet]
        //public ViewResult CreateNewStaff()
        //{
        //    ViewBag.Position = GetListPosition();
        //    return View();
        //}
        //[HttpPost]
        //public ViewResult CreateNewStaff(StaffModel staff)
        //{           
        //    return View();
        //}
        /// <summary>
        /// Danh sach khach hang
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ListCustomer(int? id)
        {

            var customer = new PagedData<CustomerModel>();

            var page = id ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("CustomerPartialView", GetPaginatedProducts(page));
            }
            var model = customerService.GetListCustomers();
            int count = model.Count();
            var listOfCustomer = (from a in model
                                  select new CustomerModel
                                  {
                                      CustID = a.CustID,
                                      CustName = a.CustName,
                                      Address = a.Address,
                                      Phone = a.Phone
                                  }).ToList();
            customer.Data = listOfCustomer.Take(pageSize);
            customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            customer.CurrentPage = 1;
            return View("ListCustomer", customer);

            //else
            //{


            //    var model = customerService.GetListCustomers();
            //    int count = model.Count();
            //    var listOfCustomer = (from a in model
            //                          select new CustomerModel
            //                          {
            //                              CustID = a.CustID,
            //                              CustName = a.CustName,
            //                              Address = a.Address,
            //                              Phone = a.Phone
            //                          }).ToList();
            //    customer.Data = listOfCustomer;
            //    customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / PageSize));
            //    customer.CurrentPage = 1;
            //    return View(customer);
            //}

            //var model = ListAllCustomer();
            //int numberPage = page ?? 1;
            //var onePageOfCustomers = model.ToPagedList(numberPage, 8);
            //ViewBag.OnePageOfCustomers = onePageOfCustomers;
            //return View();
        }
        /// <summary>
        /// Lay ve danh sach khach hang
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> ListAllCustomer()
        {
            var list = customerService.GetListCustomers();
            var model = (from item in list
                         select new CustomerModel
                         {
                             CustID = item.CustID,
                             CustName = item.CustName,
                             Image = item.Image,
                             Address = item.Address,
                             Phone = item.Phone,
                             Email = item.Email,
                             Fax = item.Fax,
                             StatusName = item.Status.StatusName,
                             BirthDate = (DateTime)item.BirthDate,
                         });
            return model;
        }
        //public ViewResult EditStaff(string staffId)
        //{
        //    var model = GetStaffByStaffId(staffId);
        //    ViewBag.Position = GetListPosition();
        //    return View(model);
        //}
        //[HttpPost]
        //public void EditStaff(StaffModel staff)
        //{
        //    var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email);
        //    staffService.UpdateStaff(model);
        //}
        ///// <summary>
        ///// Gan nhan vien co manv duoc chon tu DATABASE vao MODEL
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public StaffModel GetStaffByStaffId(string id)
        //{
        //    var item = staffService.GetStaffById(id);
        //    var model = new StaffModel();
        //    model.ID = item.StaffID;
        //    model.Image = item.Image;
        //    model.ID = item.StaffID;
        //    model.StaffName = item.StaffName;
        //    model.UserName = item.User.UserName;
        //    model.Address = item.Address;
        //    model.Email = item.Email;
        //    model.NumberPhone = item.NumberPhone;
        //    return model;
        //}
        ///// <summary>
        ///// Goi form sua thong tin nhan vien
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult EditStaffPV(string id)
        //{
        //    var model = GetStaffByStaffId(id);
        //    return PartialView("EditStaffPartialView", model);
        //}
        /// <summary>
        /// Goi form  them khach hang
        /// </summary>
        /// <returns></returns>

        public ActionResult CreateCustomerPV()
        {
            return PartialView("CreateCustomerPartialView");
        }
        ///// <summary>
        ///// Luu thong tin nhan vien
        ///// </summary>
        ///// <param name="staff"></param>
        //public void CreateStaff(StaffModel staff)
        //{
        //    var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email);
        //    staffService.CreateStaff(model);
        //}
        //public void DeleteStaff(string id)
        //{
        //    staffService.DeleteStaff(id);
        //}
        //public ActionResult GetTopCustomersFormNextSection(string lastRowId, bool isHistoryBack)
        //{
        //    var sectionCustomer = customerService.GetNextCustomerTopList(lastRowId, isHistoryBack);
        //    return Json(sectionCustomer, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Index2()
        //{

        //    var customer = new PagedData<CustomerModel>();

        //    var model = customerService.GetListCustomers();
        //    int count = model.Count();
        //    var listOfCustomer = (from a in model
        //                          select new CustomerModel
        //                          {
        //                              CustID = a.CustID,
        //                              CustName = a.CustName,
        //                              Address = a.Address,
        //                              Phone = a.Phone
        //                          }).ToList();
        //    customer.Data = listOfCustomer;
        //    customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
        //    customer.CurrentPage = 1;
        //    return View(customer);
        //}
        public ActionResult CustomerList(int page)
        {
            var customer = new PagedData<CustomerModel>();

            var model = customerService.GetListCustomers();
            int count = model.Count();
            var listOfCustomer = (from a in model
                                  select new CustomerModel
                                  {
                                      CustID = a.CustID,
                                      CustName = a.CustName,
                                      Address = a.Address,
                                      Phone = a.Phone
                                  }).ToList();
            customer.Data = listOfCustomer;
            customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            customer.CurrentPage = page;
            return PartialView(customer);
        }
        public ActionResult Product(int? id)
        {
            var page = id ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("CustomerPartialView", GetPaginatedProducts(page));
            }
            var model = customerService.GetListCustomers();
            var listOfCustomer = (from a in model
                                  select new CustomerModel
                                  {
                                      CustID = a.CustID,
                                      CustName = a.CustName,
                                      Address = a.Address,
                                      Phone = a.Phone
                                  }).ToList();
            return View("ListCustomer", listOfCustomer.Take(pageSize));
        }

        private PagedData<CustomerModel> GetPaginatedProducts(int page)
        {
            var customer = new PagedData<CustomerModel>();
            var skipRecords = page * pageSize;
            var model = customerService.GetListCustomers();
            var listOfCustomer = (from a in model
                                  select new CustomerModel
                                  {
                                      CustID = a.CustID,
                                      CustName = a.CustName,
                                      Address = a.Address,
                                      Phone = a.Phone
                                  }).ToList();
            customer.Data = listOfCustomer.OrderBy(x=>x.CustName).Skip(skipRecords).Take(pageSize).ToList();

            return customer;
        }
    }
}
