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
        private IInventoryManagerService inventoryService;
        public InventoryManagerController(IInventoryManagerService inventoryService)
        {
            this.inventoryService = inventoryService;
        }
        #endregion
        public ActionResult ListInventory()
        {
            return View();
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
        #region Check
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
        #endregion
        #region Create Action
        public ActionResult CreateNewInventory()
        {
            return View();
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
            inventoryService.CreateInventory(item);
        }
        #endregion
        #region Action Show Large View
        [HttpGet]
        public ActionResult ListInventory(int? id)
        {
            var inventory = new PagedData<InventoryModel>();
            var page = id ?? 0;
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("LargeStaffPartialView", GetPaginatedStaffs(page));//Tra ve VIEW dang GRID 
            //}
            var model = inventoryService.GetListInventory();
            int count = model.Count();
            var listOfInventory = (from a in model
                               select new InventoryModel
                               {
                                   InvtID = a.InvtID,
                                   InvtName = a.InvtName,
                                   UnitRate =(int) a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate != null).First().UnitRate,
                                   QtyStock = a.QtyStock,
                                   UnitName = a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate == null).First().Unit.UnitName,
                                   SalePrice_L = (int)a.UnitDetails.Where(x => x.InvtID == a.InvtID && x.UnitRate == null).First().SalePrice,
                               }).ToList();
            inventory.Data = listOfInventory;
            //staff.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            //staff.CurrentPage = 1;
            //staff.Count = count;
            //staff.PageSize = pageSize;
            return View("ListInventory", inventory);
        }
        #endregion

    }
}
