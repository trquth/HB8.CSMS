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
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace HB8.CSMS.MVC.Controllers
{

    public class StaffManagerController : Controller
    {
        #region  Khai bao
        public const int pageSize = 10;//So nhan vien duoc hien thi tren mot trang
        private IStaffManagerService staffService;
        private IBillSaleOrderManagerService billSaleOrderService;
        private IInventoryManagerService inventoryService;
        public StaffManagerController(IStaffManagerService staffService, IInventoryManagerService inventoryService, IBillSaleOrderManagerService billSaleOrderService)
        {
            this.staffService = staffService;
            this.inventoryService = inventoryService;
            this.billSaleOrderService = billSaleOrderService;
        }
        #endregion
        #region Code show danh sach nhan vien dang GRID VIEW
        public ActionResult ReturnIndex()
        {
            var staff = new PagedData<StaffModel>();
            var model = staffService.GetListStaff();
            int count = model.Count();
            var listOfStaff = (from a in model
                               select new StaffModel
                               {
                                   Image = a.Image,
                                   ID = a.StaffID,
                                   StaffName = a.StaffName,
                                   NumberPhone = a.NumberPhone,
                                   Address = a.Address,
                                   UserId = a.UserId,
                                   Deleted = a.Deleted
                               }).ToList();
            //staff.Data = listOfStaff.Take(pageSize);
            staff.Data = listOfStaff;
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.CurrentPage = 1;
            staff.Count = count;
            staff.PageSize = pageSize;
            return PartialView("LargeStaffPartialView", staff);
        }
        public ActionResult Index()
        {
            var staff = new PagedData<StaffModel>();
            var model = staffService.GetListStaff();
            int count = model.Count();
            var listOfStaff = (from a in model
                               select new StaffModel
                               {
                                   Image = a.Image,
                                   ID = a.StaffID,
                                   StaffName = a.StaffName,
                                   NumberPhone = a.NumberPhone,
                                   Address = a.Address,
                                   UserId = a.UserId,
                                   Deleted = a.Deleted
                               }).ToList();
            //staff.Data = listOfStaff.Take(pageSize);
            staff.Data = listOfStaff;
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.CurrentPage = 1;
            staff.Count = count;
            staff.PageSize = pageSize;
            return PartialView("IndexPartialView", staff);
        }
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
                                   Image = a.Image,
                                   ID = a.StaffID,
                                   StaffName = a.StaffName,
                                   NumberPhone = a.NumberPhone,
                                   Address = a.Address,
                                   Deleted = a.Deleted
                               }).ToList();
            //staff.Data = listOfStaff.Take(pageSize);
            staff.Data = listOfStaff;
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
                                   Image = a.Image,
                                   Address = a.Address,
                                   NumberPhone = a.NumberPhone,
                                   Email = a.Email,
                                   UserName = a.User.UserName,
                                   Deleted =a.Deleted
                               }).Skip(skipRecords).Take(pageSize).ToList();
            staff.Data = listOfStaff;
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.Count = count;
            staff.PageSize = pageSize;
            staff.CurrentPage = page + 1;
            return staff;
        }
        /// <summary>
        /// Hien thi danh sach nhan vien dang LIST VIEW
        /// </summary>
        /// <returns></returns>
        public ActionResult ListStaffView(int? page)
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
            return PartialView("ListStaffPartialView", GetPaginatedStaffs(pageNumber));
        }
        #endregion
        #region Ham tra ve danh sach theo dang JSON
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
        /// Tra ve so thu tu 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult IndexOfStaff(string id)
        {
            int index = staffService.ReturnIndexStaff(id);
            int count = staffService.GetListStaff().Count();
            var model = new PagedData<StaffModel>();
            model.Count = count;
            model.Index = index;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Method

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
            model.UserId = item.User.UserID;
            model.Address = item.Address;
            model.Email = item.Email;
            model.NumberPhone = item.NumberPhone;
            model.Role = item.User.Role;
            return model;
        }
        /// <summary>
        /// Ham ma hoa MD5
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        #endregion
        #region Ham hien thi chi tiet
        public ActionResult DetailStaff(string staffId)
        {
            var model = GetStaffByStaffId(staffId);
            return PartialView("DetailStaffPartialView", model);
        }
        #endregion
        #region Ham sua
        public ActionResult ListPositonForStaff()
        {
            var model = GetListPosition();
            return PartialView("DropdownListPositionPartialView", model);
        }
        public void EditStaff(StaffModel staff)
        {
            string pass = staff.ConfirmPassword;
            string passMD5 = Encrypt(pass, true);
            var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email, passMD5);
            staffService.UpdateStaff(model);
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
        #region Ham luu
        /// <summary>
        /// Goi form  them nhan vien
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateNewStaff()
        {
            return PartialView("CreateStaffPartialView");
        }
        /// <summary>
        /// Luu thong tin nhan vien
        /// </summary>
        /// <param name="staff"></param>
        public void CreateStaff(StaffModel staff)
        {
            string pass = staff.ConfirmPassword;
            string passMD5 = Encrypt(pass, true);
            var model = new StaffDomain(staff.ID, staff.UserId, staff.StaffName, staff.Image, staff.Address, staff.NumberPhone, staff.Email, passMD5);
            staffService.CreateStaff(model);
        }
        #endregion

        /// <summary>
        /// Xoa thong tin nhan vien
        /// </summary>
        /// <param name="id"></param>
        public void DeleteStaff(string id)
        {
            bool check = CheckStaffBeforeDelete(id);
            if (check)
            {
                staffService.DeleteStaff(id);
            }
            else
            {
                staffService.DeleteStaffIfStaffExit(id);
            }

        }
        /// <summary>
        /// Kiem tra xem co the xoa nhan vien nay duoc khong
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckStaffBeforeDelete(string id)
        {
            string staffID = id.ToLower();
            var listInventory = inventoryService.GetListInventory();
            var listBill = billSaleOrderService.GetListBill();
            foreach (var item in listInventory)
            {
                if (item.StaffId.ToLower().Equals(staffID))
                {
                    return false;
                }
            }
            foreach (var item in listBill)
            {
                if (item.StaffID.ToLower().Equals(staffID))
                {
                    return false;
                }
            }
            return true;

        }
        #region Code xu li Next va Privous
        /// <summary>
        /// Lay Ma khach hang tiep theo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string FindNextID(string id)
        {
            string lastId = staffService.GetListStaff().LastOrDefault().StaffID.ToString();
            //Kiem tra xem MNV vua nhan co phai la MNV cuoi cung k
            if (lastId == id)
            {
                return id;
            }
            else
            {
                string nextId = staffService.GetListStaff().SkipWhile(x => x.StaffID != id).Skip(1).FirstOrDefault().StaffID.ToString();
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
            var startId = staffService.GetListStaff().FirstOrDefault().StaffID.ToString();
            if (startId == id)
            {
                return startId;
            }
            else
            {
                string previousId = staffService.GetListStaff().TakeWhile(x => x.StaffID != id).LastOrDefault().StaffID.ToString();
                return previousId;
            }
        }
        /// <summary>
        /// Hien thi khach hang tiep theo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult NextStaff(string id)
        {
            string nextId = FindNextID(id);
            var model = GetStaffByStaffId(nextId);
            return PartialView("DetailStaffPartialView", model);
        }
        public ActionResult PreviousStaff(string id)
        {
            string previousId = FindPreviousID(id);
            var model = GetStaffByStaffId(previousId);
            return PartialView("DetailStaffPartialView", model);
        }
        #endregion
        #region Show NAVBAR
        public ActionResult NavBar()
        {
            return PartialView("PanelForStaffPartialView");
        }
        #endregion

    }
}
