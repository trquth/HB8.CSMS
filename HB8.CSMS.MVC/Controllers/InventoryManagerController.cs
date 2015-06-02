using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.MVC.Models.Inventory;
using HB8.CSMS.MVC.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB8.CSMS.MVC.Controllers
{
    public class InventoryManagerController : Controller
    {
        #region Variables
        public const int pageSize = 2;//So san pham duoc hien thi tren mot trang
        private IInventoryManagerService inventoryService;
        public InventoryManagerController(IInventoryManagerService inventoryService)
        {
            this.inventoryService = inventoryService;
        }
        #endregion Show Large View
        public ActionResult ListInventory(int? id)
        {
            var inventory = new PagedData<InventoryModel>();
            var page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("LargeInventoryPartialView", GetPaginatedInventories(page));//Tra ve VIEW dang GRID 
            }
            var model = inventoryService.GetListInventory();
            int count = model.Count();
            var listOfStaff = (from item in model
                               select new InventoryModel
                               {
                                   InvtID = item.InvtID,
                                   InvtName = item.InvtName,
                                   ClassName = item.Class.ClassName,
                                   UnitRate = (int)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().UnitRate,
                                   QtyStock = item.QtyStock,
                                   Description = item.Description,
                                   StaffName = item.Staff.StaffName,
                                   StockName = item.Stock.StockName,
                                   SalePrice_L = (decimal)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate == null).First().SalePrice,
                                   SalePrice_T = (decimal)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().SalePrice,
                                   Image = item.Image,
                                   UnitName_L = item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate == null).First().Unit.UnitName,
                                   UnitName_T = item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().Unit.UnitName,
                                   StInvetoryName = item.StatusIventory.StInvetoryName,
                                   SlsTax = item.SlsTax,
                               }).ToList();
            inventory.Data = listOfStaff.Take(pageSize);
            inventory.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            inventory.CurrentPage = 1;
            inventory.Count = count;
            inventory.PageSize = pageSize;
            return View("ListInventory", inventory);
        }
        #region Action For Dropdownlist
        /// <summary>
        /// Lay  danh sach cac nhom san pham
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListClass()
        {
            var model = inventoryService.GetListInventoryClass();
            var data = (from a in model
                        select new InventoryModel
                        {
                            ClassId = a.ClassId,
                            ClassName = a.ClassName,
                        }).OrderBy(x => x.ClassName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lay  danh sach don vi tinh cho Thung
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListUnitT()
        {
            var model = inventoryService.GetUnitForT();
            var data = (from a in model
                        select new InventoryModel
                        {
                            UnitID_T = a.UnitID,
                            UnitName = a.UnitName,
                        }).OrderBy(x => x.ClassName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lay  danh sach don vi tinh cho Le
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListUnitL()
        {
            var model = inventoryService.GetUnitForL();
            var data = (from a in model
                        select new InventoryModel
                        {
                            UnitID_L = a.UnitID,
                            UnitName = a.UnitName,
                        }).OrderBy(x => x.UnitName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Tra ve trang thai san pham
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListStatus()
        {
            var model = inventoryService.GetStatusForInventory();
            var data = (from a in model
                        select new InventoryModel
                        {
                            StInventoryId = a.StInventoryId,
                            StInvetoryName = a.StInvetoryName,
                        }).OrderBy(x => x.StInvetoryName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Tra ve danh sach nhan vien
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListStaff()
        {
            var model = inventoryService.GetListStaff();
            var data = (from a in model
                        select new InventoryModel
                        {
                            StaffId = a.StaffID,
                            StaffName = a.StaffName,
                        }).OrderBy(x => x.StaffName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Tra ve danh sach kho hang
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListStock()
        {
            var model = inventoryService.GetListStock();
            var data = (from a in model
                        select new InventoryModel
                        {
                            StockID = a.StockID,
                            StockName = a.StockName,
                        }).OrderBy(x => x.StockName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Show List View
         /// <summary>
        /// Hien thi danh sach nhan vien dang LIST VIEW
        /// </summary>
        /// <returns></returns>
        public ActionResult ListInventoryView(int? page)
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
            return View("ListInventoryPartialView", GetPaginatedInventories(pageNumber));
        }
        #endregion
        #region Method
        /// <summary>
        /// Kiem tra ma nv co ton tai hay khong 
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns>Tra ve mot json mang gia tri true khi ID ton tai ton tai, nguoc lai false </returns>
        [HttpGet]
        public JsonResult HaveInventoryId(string Id)
        {
            var model = inventoryService.GetInventoryById(Id);
            bool data = false;
            if (model != null)
            {
                data = true;
            }
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Tra ve thong tin chi tiet cua mat hang dua vao cua mat hang do
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryModel GetInventoryByID(string id)
        {
            var item = inventoryService.GetInventoryById(id);
            var model = new InventoryModel();
            model.InvtID = item.InvtID;
            model.InvtName = item.InvtName;
            model.ClassName = item.ClassName;
            model.UnitRate = item.UnitRate;
            model.QtyStock = item.QtyStock;
            model.Description = item.Description;
            model.StaffName = item.StaffName;
            model.StockName = item.StockName;
            model.SalePrice_L = item.SalePrice_L;
            model.SalePrice_T = item.SalePrice_T;
            model.StaffName = item.StaffName;
            model.Image = item.Image;
            model.UnitName_L = item.UnitName_L;
            model.UnitName_T = item.UnitName_T;
            model.StInvetoryName = item.StInvetoryName;
            model.SlsTax = item.SlsTax;
            return model;
        }
        /// <summary>
        /// Nhan ve danh sach thong tin STAFF de hien thi
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private PagedData<InventoryModel> GetPaginatedInventories(int page)
        {
            var staff = new PagedData<InventoryModel>();
            var skipRecords = page * pageSize;
            var model = inventoryService.GetListInventory();
            int count = model.Count();
            var listOfStaff = (from item in model
                               select new InventoryModel
                               {
                                   InvtID = item.InvtID,
                                   InvtName = item.InvtName,
                                   ClassName = item.Class.ClassName,
                                   UnitRate = (int)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().UnitRate,
                                   QtyStock = item.QtyStock,
                                   Description = item.Description,
                                   StaffName = item.Staff.StaffName,
                                   StockName = item.Stock.StockName,
                                   SalePrice_L = (decimal)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate == null).First().SalePrice,
                                   SalePrice_T =(decimal)item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().SalePrice,
                                   Image = item.Image,
                                   UnitName_L = item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate == null).First().Unit.UnitName,
                                   UnitName_T = item.UnitDetails.Where(x => x.InvtID == item.InvtID && x.UnitRate != null).First().Unit.UnitName,
                                   StInvetoryName = item.StatusIventory.StInvetoryName,
                                   SlsTax = item.SlsTax,
                               }).OrderBy(x => x.StaffName).Skip(skipRecords).Take(pageSize).ToList();
            staff.Data = listOfStaff;
            staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            staff.Count = count;
            staff.PageSize = pageSize;
            staff.CurrentPage = page + 1;
            return staff;
        }
        #endregion
        #region Create Action
        public ActionResult CreateNewInventory()
        {
            return PartialView("CreateInventoryPartialView");
        }
        public void CrateNewInventory(InventoryModel model)
        {
            var item = new InventoryDomain();
            item.InvtID = model.InvtID;
            item.InvtName = model.InvtName;
            item.ClassId = model.ClassId;
            item.UnitID_L = model.UnitID_L;
            item.UnitID_T = model.UnitID_T;
            item.QtyStock = model.QtyStock;
            item.StInventoryId = model.StInventoryId;
            item.Description = model.Description;
            item.StaffId = model.StaffId;
            item.StockID = model.StockID;
            item.SalePrice_L = model.SalePrice_L;
            item.SalePrice_T = model.SalePrice_T;
            item.UnitRate = model.UnitRate;
            item.Image = model.Image;
            inventoryService.CreateInventory(item);
        }
        #endregion
       
        [HttpGet]
        //public ActionResult ListInventory(int? id)
        //{
        //    var inventory = new PagedData<InventoryModel>();
        //    var page = id ?? 0;
        //    //if (Request.IsAjaxRequest())
        //    //{
        //    //    return PartialView("LargeStaffPartialView", GetPaginatedStaffs(page));//Tra ve VIEW dang GRID 
        //    //}
        //    var model = inventoryService.GetListInventory();
        //    int count = model.Count();
        //    var listOfInventory = (from a in model
        //                           select new InventoryModel
        //                           {
        //                               InvtID = a.InvtID,
        //                               InvtName = a.InvtName,
        //                               UnitRate = (int)a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate != null).First().UnitRate,
        //                               QtyStock = a.QtyStock,
        //                               UnitName = a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate == null).First().Unit.UnitName,
        //                               SalePrice_L = (int)a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate == null).First().SalePrice,
        //                           }).ToList();
        //    inventory.Data = listOfInventory;
        //    //staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
        //    //staff.CurrentPage = 1;
        //    //staff.Count = count;
        //    //staff.PageSize = pageSize;
        //    return View("ListInventory", inventory);
        //}
    
        #region Detail Inventory
        public ActionResult DetailInventory(string id)
        {
            var model = GetInventoryByID(id);
            return View("DetailInventoryPartialView", model);
        }
        #endregion
        #region Edit Action
        /// <summary>
        /// Hien thi form EDIT san pham
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditInventory(string id)
        {
            var model = GetInventoryByID(id);
            return PartialView("EditInventoryPartialView", model);
        }
        [HttpPost]
        public void EditInventory(InventoryModel inventory)
        {
            var model = new InventoryDomain();
            model.InvtID = inventory.InvtID;
            model.InvtName = inventory.InvtName;
            model.ClassId = inventory.ClassId;
            model.UnitID_L = inventory.UnitID_L;
            model.UnitID_T = inventory.UnitID_T;
            model.QtyStock = inventory.QtyStock;
            model.StInventoryId = inventory.StInventoryId;
            model.Description = inventory.Description;
            model.StaffId = inventory.StaffId;
            model.StockID = inventory.StockID;
            model.SalePrice_L = inventory.SalePrice_L;
            model.SalePrice_T = inventory.SalePrice_T;
            model.UnitRate = inventory.UnitRate;
            model.Image = inventory.Image;
            inventoryService.UpdateInventory(model);
        }
        #endregion

    }
}
