using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.MVC.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HB8.CSMS.MVC.Models.Paging;
using HB8.CSMS.BLL.DomainModels;

namespace HB8.CSMS.MVC.Controllers
{
    public class CustomerManagerController : Controller
    {
        private ICustomerManagerService customerService;
        //const int recordsPerPage = 1;
        public const int pageSize = 1;
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
            customer.Count = count;
            customer.PageSize = pageSize;
            return View("ListCustomer", customer);
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
        #region Ghi chu


        public ViewResult EditCustomer(string custId)
        {
            var model = GetStaffByStaffId(custId);
            //ViewBag.Position = GetListPosition();
            return View(model);
        }
        [HttpPost]
        public void EditCustomer(CustomerModel customer)
        {
            var model = new CustomerDomain(customer.CustID, customer.CustName, customer.Address,
                customer.Phone, customer.Fax, customer.Email, customer.Overdue, (decimal)customer.Amount, (decimal)customer.OverdueAmt,
                (decimal)customer.DueAmt, customer.StatusID, customer.Description, customer.BirthDate, (DateTime)customer.CreateDate, customer.Image);
            customerService.UpdateCustomer(model);
        }
        /// <summary>
        /// Gan nhan vien co manv duoc chon tu DATABASE vao MODEL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerModel GetStaffByStaffId(string id)
        {
            var item = customerService.GetCustomerById(id);
            var model = new CustomerModel();
            model.CustID = item.CustID;
            model.CustName = item.CustName;
            model.Address = item.Address;
            model.Phone = item.Phone;
            model.Fax = item.Fax;
            model.Email = item.Email;
            model.Overdue = item.Overdue;
            model.Amount = item.Amount;
            model.OverdueAmt = item.OverdueAmt;
            model.DueAmt = item.DueAmt;
            model.StatusID = item.StatusID;
            model.Description = item.Description;
            model.BirthDate = (DateTime)item.BirthDate;
            model.CreateDate = item.CreateDate;
            model.Image = item.Image;
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
        #endregion
        /// <summary>
        /// Goi form  them khach hang
        /// </summary>
        /// <returns></returns>

        public ActionResult CreateCustomerPV()
        {
            return PartialView("CreateCustomerPartialView");
        }
        #region  Ghi chu


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
        #endregion
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
                                  }).OrderBy(x => x.CustName).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            customer.Data = listOfCustomer;
            customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            customer.CurrentPage = page;
            //return Json(customer, JsonRequestBehavior.AllowGet);
            return PartialView("CustomerPartialView", customer);
        }
        private PagedData<CustomerModel> GetPaginatedProducts(int page)
        {
            var customer = new PagedData<CustomerModel>();
            var skipRecords = page * pageSize;
            var model = customerService.GetListCustomers();
            int count = model.Count();
            var listOfCustomer = (from a in model
                                  select new CustomerModel
                                  {
                                      CustID = a.CustID,
                                      CustName = a.CustName,
                                      Address = a.Address,
                                      Phone = a.Phone
                                  }).OrderBy(x => x.CustName).Skip(skipRecords).Take(pageSize).ToList();
            customer.Data = listOfCustomer;
            customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            customer.Count = count;
            customer.PageSize = pageSize;
            return customer;
        }
        public ActionResult DetailCustomer(string custId)
        {
            var model = GetCustomerDetail(custId);
            return PartialView("DetailCustomerParitalView", model);
        }
        private CustomerModel GetCustomerDetail(string custId)
        {
            var customer = new CustomerModel();
            var model = customerService.GetCustomerById(custId);
            customer.Image = model.Image;
            customer.CustName = model.CustName;
            customer.Address = model.Address;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            customer.Email = model.Email;
            customer.Overdue = model.Overdue;
            customer.Amount = model.Amount;
            customer.OverdueAmt = model.OverdueAmt;
            customer.DueAmt = model.DueAmt;
            customer.StatusID = model.StatusID;
            customer.Description = model.Description;
            customer.BirthDate = (DateTime)model.BirthDate;
            customer.CreateDate = model.CreateDate;
            return customer;
        }
    }
}
