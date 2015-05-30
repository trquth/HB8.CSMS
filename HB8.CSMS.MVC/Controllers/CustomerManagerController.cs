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
        #region Khai bao
        private ICustomerManagerService customerService;
        public const int pageSize = 1;//So nhan vien duoc hien thi tren mot trang
        public CustomerManagerController(ICustomerManagerService customerService)
        {
            this.customerService = customerService;
        }
        #endregion
        #region Ghi chu 2
        /// <summary>
        /// Trả về một danh sách các chức vụ dang JSON
        /// </summary>
        /// <returns>JSON</returns>


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
        #endregion
        #region Code xu li trang LIST CUSTOMER
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
                return PartialView("LargeCustomerPartialView", GetPaginatedProducts(page));//Tra ve VIEW dang GRID 
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
        public ActionResult ListCustomerView(int?page)
        {
            var pageNumber = 0;
            if (page == null)
            {
                pageNumber = page ?? 0;
            }
            else
            {
                pageNumber = (int)page - 1;
            }
            return View("ListCustomerPartialView", GetPaginatedProducts(pageNumber));
        }
        #endregion
        #region Code xu li phan phan trang
        /// <summary>
        /// Xu li phan trang dang LIST 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
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
                                      Phone = a.Phone,
                                      Email = a.Email
                                  }).OrderBy(x => x.CustName).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            customer.Data = listOfCustomer;
            customer.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            customer.CurrentPage = page;
            return PartialView("ListCustomerPartialView", customer);
        }

        /// <summary>
        /// Nhan ve danh sach thong tin CUSTOMER de hien thi
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
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

     
        #endregion
        #region Code xu li hien thi thong tin chi tiet cua CUSTOMER
        /// <summary>
        /// Lay thong tin chi tiet cua khach hang dua vao Id
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        private CustomerModel GetCustomerDetail(string custId)
        {
            var customer = new CustomerModel();
            var model = customerService.GetCustomerById(custId);
            customer.CustID = model.CustID;
            customer.Image = model.Image;
            customer.CustName = model.CustName;
            customer.Address = model.Address;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            customer.Email = model.Email;
            customer.StatusID = model.StatusID;
            customer.Description = model.Description;
            customer.BirthDate = (DateTime)model.BirthDate;
            customer.CreateDate = model.CreateDate;
            return customer;
        }
        /// <summary>
        /// Hien thi thong tin chi tiet cua CUSTOMER
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public ActionResult DetailCustomer(string custId)
        {
            var model = GetCustomerDetail(custId);
            return PartialView("DetailCustomerParitalView", model);
        }
        /// <summary>
        /// Lay ve thong tin CUSTOMER dua vao ID
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        #endregion
        #region Code phan EDIT CUSTOMER
        /// <summary>
        /// Lay tu ve danh sach status trong database
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
        public ViewResult EditCustomer(string custId)
        {
            var model = GetCustomerByCustomerId(custId);
            //ViewBag.Position = GetListPosition();
            return View(model);
        }
        [HttpPost]
        public void EditCustomer(CustomerModel customer)
        {
            var dateCreate = DateTime.Now;
            var model = new CustomerDomain(customer.CustID, customer.CustName, customer.Address,
                customer.Phone, customer.Fax, customer.Email, customer.StatusID, customer.Description, customer.BirthDate, dateCreate, customer.Image);
            customerService.UpdateCustomer(model);
        }
        /// <summary>
        /// Gan nhan vien co manv duoc chon tu DATABASE vao MODEL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerModel GetCustomerByCustomerId(string id)
        {
            var item = customerService.GetCustomerById(id);
            var model = new CustomerModel();
            model.CustID = item.CustID;
            model.CustName = item.CustName;
            model.Address = item.Address;
            model.Phone = item.Phone;
            model.Fax = item.Fax;
            model.Email = item.Email;
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
        public ActionResult EditCustomerPV(string id)
        {
            var model = GetCustomerByCustomerId(id);
            return PartialView("EditCustomerPartialView", model);
        }
        /// <summary>
        /// Goi lai PartialView sau khi edit CUSTOMER de show lai
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult CallBackCustomerPartialView(int page)
        {
            return PartialView("CustomerPartialView", GetCustomerAfterEdit(page));
        }
        #region * Y tuong
        //Luc dau dinh lam la se dung JQUERY thay doi gia tri trong cac cot cua LIST thoi
        #endregion
        /// <summary>
        /// Tra ve doi tuong sau khi da sua
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PagedData<CustomerModel> GetCustomerAfterEdit(int page)
        {
            var customer = new PagedData<CustomerModel>();
            var skipRecords = (page - 1) * pageSize;//chi den du lieu trong phan phan trang truoc do
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
            customer.CurrentPage = page;//chi trang hien tai dang sua
            return customer;
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
       
        #region Code xu li Next va Privous
        /// <summary>
        /// Lay Ma khach hang tiep theo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string FindNextID(string id)
        {
            string lastId = customerService.GetListCustomers().LastOrDefault().CustID.ToString();
            //Kiem tra xem MKH vua nhan co phai la MKH cuoi cung k
            if (lastId == id)
            {
                return id;
            }
            else
            {
                string nextId = customerService.GetListCustomers().SkipWhile(x => x.CustID != id).Skip(1).FirstOrDefault().CustID.ToString();
                return nextId;
            }          
        }
        /// <summary>
        /// Lay ma khach hang truoc do
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string FindPreviousID(string id)
        {
            var startId = customerService.GetListCustomers().FirstOrDefault().CustID.ToString();
            if (startId==id)
            {
                return startId;
            }
            else
            {
                string previousId = customerService.GetListCustomers().TakeWhile(x => x.CustID != id).LastOrDefault().CustID.ToString();
                return previousId;
            }         
        }
        /// <summary>
        /// Hien thi khach hang tiep theo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult NextCustomer(string id)
        {
            string nextId = FindNextID(id);
            var model = GetCustomerDetail(nextId);
            return PartialView("DetailCustomerParitalView", model);
        }
        public ActionResult PreviousCustomer(string id)
        {
            string previousId = FindPreviousID(id);
            var model = GetCustomerDetail(previousId);
            return PartialView("DetailCustomerParitalView", model);
        }
        #endregion

    }
}
