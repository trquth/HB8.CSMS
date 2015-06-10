using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HB8.CSMS.MVC.Models.BillSaleOrder;
using HB8.CSMS.BLL.DomainModels;

namespace HB8.CSMS.MVC.Controllers
{
    public class BillSaleOrderManagerController : Controller
    {
        #region Variables
        public const int pageSize = 2;//So san pham duoc hien thi tren mot trang
        private IBillSaleOrderManagerService billSaleOrderService;
        public BillSaleOrderManagerController(IBillSaleOrderManagerService billSaleOrderService)
        {
            this.billSaleOrderService = billSaleOrderService;
        }
        #endregion
        #region Action For Dropdownlist
        /// <summary>
        /// Lay  danh sach khach hang
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListCustomer()
        {
            var model = billSaleOrderService.GetListCustomers();
            var data = (from a in model
                        select new BillSaleOrderModel
                        {
                            CustID = a.CustID,
                            CustName = a.CustName
                        }).OrderBy(x => x.CustName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Tra ve danh sach nhan vien
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListStaff()
        {
            var model = billSaleOrderService.GetListStaff();
            var data = (from a in model
                        select new BillSaleOrderModel
                        {
                            StaffId = a.StaffID,
                            StaffName = a.StaffName,
                        }).OrderBy(x => x.StaffName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lay  danh sach don vi tinh dua vao ma san pham
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public JsonResult ListUnitDetailByInvtID(string id)
        {
            var model = billSaleOrderService.GetUnitDetailByID(id);
            var data = new BillSaleOrderModel();
            data.UnitName_L = model.Where(x => x.UnitRate == null).First().Unit.UnitName;
            data.UnitName_T = model.Where(x => x.UnitRate != null).First().Unit.UnitName;
            data.SalePrice_L = (decimal)model.Where(x => x.UnitRate == null).First().Unit.UnitDetails.Where(x => x.UnitRate == null).First().SalePrice;
            data.SalePrice_L = (decimal)model.Where(x => x.UnitRate != null).First().Unit.UnitDetails.Where(x => x.UnitRate != null).First().SalePrice;
            data.UnitRate = (int)model.Where(x => x.UnitRate != null).First().UnitRate;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Show Row and Column
        //Hien thi hang nhap du lieu
        public ActionResult ShowRow()
        {
            var model = billSaleOrderService.GetListInventory();
            var data = (from a in model
                        select new BillSaleOrderModel
                        {
                            InvtID = a.InvtID,
                            InvtName = a.InvtName,
                        }).OrderBy(x => x.InvtName);
            return PartialView("RowInventoryOfBillSaleOrderPartialView", data);
        }
        //Hien thi cot gia tri
        public ActionResult ShowColumnUnit(string id)
        {
            var model = billSaleOrderService.GetUnitDetailByID(id);
            var data = new BillSaleOrderModel();
            data.UnitName_L = model.Where(x => x.UnitRate == null).First().Unit.UnitName;
            data.UnitName_T = model.Where(x => x.UnitRate != null).First().Unit.UnitName;
            data.UnitID_L = model.Where(x => x.UnitRate == null).First().Unit.UnitID;
            data.UnitID_T = model.Where(x => x.UnitRate != null).First().Unit.UnitID;
            return PartialView("ColumnUnitOfBillSaleOrderPartialView", data);
        }
        //Hien thi cot don gia
        public ActionResult ShowColumnPrice(int? id, string idInventory)
        {
            var data = new BillSaleOrderModel();
            if (id == null)
            {

                data.SalesPrice = 0;
            }
            else
            {
                var model = billSaleOrderService.GetUnitDetailByID(idInventory);
                int idL = model.Where(x => x.UnitRate == null).First().Unit.UnitID;
                if (idL == id)
                {
                    data.SalesPrice = (decimal)model.Where(x => x.UnitRate == null).First().Unit.UnitDetails.Where(x => x.UnitRate == null).First().SalePrice;
                }
                else
                {
                    data.SalesPrice = (decimal)model.Where(x => x.UnitRate != null).First().Unit.UnitDetails.Where(x => x.UnitRate != null).First().SalePrice;
                }
                data.UnitRate = (int)model.Where(x => x.UnitRate != null).First().UnitRate;
            }

            return PartialView("ColumnPriceOfBillOrderPartialView", data);
        }
        //Hien thi cot tinh tien
        public ActionResult TotalPrice(int quantity, decimal price, decimal tax)
        {
            var data = new BillSaleOrderModel();
            data.SalesPrice = quantity * price * (1 + tax / 100);
            return PartialView("ColumnTotalPriceInventoryOfBillPatialView", data);
        }
        #endregion
        #region Save in Session
        public void Update(int id, string invtId, int quantity, decimal salePrice, decimal tax, decimal amount)
        {
            var oderDetails = Session["Order"] as List<BillSaleOrderModel>;
            if (oderDetails == null)
            {
                oderDetails = new List<BillSaleOrderModel>();
                var item = new BillSaleOrderModel
                {
                    ID = id,
                    InvtID = invtId,
                    Qty = quantity,
                    SalesPrice = salePrice,
                    Discount = 0,
                    TaxAmtForInventory = tax,
                    Amount = amount,
                };
                oderDetails.Add(item);
            }
            else
            {
                var item = oderDetails.FirstOrDefault(x => x.ID == id);
                if (item == null)
                {
                    oderDetails = new List<BillSaleOrderModel>();
                    var itemOrder = new BillSaleOrderModel
                    {
                        ID = id,
                        InvtID = invtId,
                        Qty = quantity,
                        SalesPrice = salePrice,
                        Discount = 0,
                        TaxAmtForInventory = tax,
                        AmountForInventory = amount,
                        
                    };
                    oderDetails.Add(itemOrder);
                }
                else
                {
                    item.InvtID = invtId;
                    item.Qty = quantity;
                    item.SalesPrice = salePrice;
                    item.TaxAmtForInventory = tax;
                    item.AmountForInventory = amount;
                }

            }
            Session["Order"] = oderDetails;
        }
        #endregion
        #region Create Action
        public ActionResult CreateNewBillOrder()
        {
            return PartialView("CreateBillSaleOrderPartialView");
        }
        //Ham tao moi mot hoa don
        public void CreateNewBillOrder(BillSaleOrderDomain model)
        {
            var item = new List<BillSaleOrderDomain>();
            var list = GetListDetailInventory();
            var items = from a in list
                        select new BillSaleOrderDomain
                        {
                            OrderDate = model.OrderDate,
                            InvoiceType = model.InvoiceType,
                            CustID = model.CustID,
                            TaxAmt = TotalTaxAmt(),
                            TotalAmt = TotalAmt(),
                            Description = model.Description,
                            InvtID = a.InvtID,
                            Qty = a.Qty,
                            SalesPrice = a.SalesPrice,
                            TaxAmtForInventory = a.TaxAmtForInventory,
                            Discount = a.Discount,
                            Amount = a.Amount,
                            UnitID =a.UnitID,
                            Payment =0,
                            Debt = 0,                            
                        };
            billSaleOrderService.CreateBillSaleOrder(items);
        }
        #endregion
        #region Method
        //Tra ve danh sach san pham duoc luu
        private List<BillSaleOrderModel> GetListDetailInventory()
        {
            return Session["Order"] as List<BillSaleOrderModel>;
        }
        //Tra ve tong thue cho cac mat hang
        private decimal TotalTaxAmt()
        {
            decimal total = 0;
            var list = GetListDetailInventory();
            foreach (var item in list)
            {
                total += item.TaxAmtForInventory;
            }
            return total;
        }
        //Tra ve tong gia tri hoa don
        private decimal TotalAmt()
        {
            decimal total = 0;
            var list = GetListDetailInventory();
            foreach (var item in list)
            {
                total += item.AmountForInventory;
            }
            return total;
        }
        #endregion
        public ActionResult ListBillSaleOrder()
        {
            return View();
        }

    }
}
