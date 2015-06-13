using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HB8.CSMS.MVC.Models.BillSaleOrder;
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.MVC.Models.Paging;
using System.Globalization;

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
            var data = new BillSaleOrderModel();
            if (id != "")
            {
                var model = billSaleOrderService.GetUnitDetailByID(id);
                data.UnitName_L = model.Where(x => x.UnitRate == null).First().Unit.UnitName;
                data.UnitName_T = model.Where(x => x.UnitRate != null).First().Unit.UnitName;
                data.UnitID_L = model.Where(x => x.UnitRate == null).First().Unit.UnitID;
                data.UnitID_T = model.Where(x => x.UnitRate != null).First().Unit.UnitID;
            }
            else
            {
                data = null;
            }
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
        public ActionResult TotalPrice(int quantity, decimal price, decimal tax, decimal overDisc)
        {
            var data = new BillSaleOrderModel();
            decimal priceOverDisc = price * (1 - (overDisc / 100));//Tinh gia da chiec khau
            decimal priceTax = priceOverDisc + (price * (tax / 100));//Gia da tinh thue
            data.SalesPrice = priceTax * quantity;//Gia tinh thue
            return PartialView("ColumnTotalPriceInventoryOfBillPatialView", data);
        }
        #endregion
        #region Create Action
        public ActionResult CreateNewBillOrder()
        {
            return PartialView("CreateBillSaleOrderPartialView");
        }
        //Ham tao moi mot hoa don
        public void CreateBillOrder(BillSaleOrderDomain model)
        {
            var item = new List<BillSaleOrderDomain>();
            var list = GetListDetailInventory();
            var items = from a in list
                        select new BillSaleOrderDomain
                        {
                            //Bang BILLSALEORDER
                            OrderDate = model.OrderDate,
                            CustID = model.CustID,
                            OverdueDate = model.OverdueDate,
                            OrderDisc = model.OrderDisc,
                            TaxAmt = TotalTaxAmt(),
                            TotalAmt = TotalAmt(),
                            Payment = 0,
                            Debt = 0,
                            Description = model.Description,
                            StaffId = model.StaffId,
                            InvoiceID = "AB",
                            //Bang BILLSALEORDERDETAIL
                            InvtID = a.InvtID,
                            Qty = a.Qty,
                            SalesPrice = a.SalesPrice,
                            Discount = 0,
                            TaxAmtForInventory = a.TaxAmtForInventory,
                            Amount = a.Amount,
                            UnitID = a.UnitID,
                            OrderDiscForInvt = a.OrderDiscForInvt
                        };
            billSaleOrderService.CreateBillSaleOrder(items);
            Session.Remove("Order");//Xoa di session luu thong tin danh sach mat hang
        }
        #endregion
        #region Method
        //Luu danh sach hoa don vao Session
        public void Update(int id, string invtId, int quantity, decimal salePrice, decimal tax, decimal amount, int unitId, decimal orderDisc)
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
                    UnitID = unitId,
                    OrderDiscForInvt = orderDisc
                };
                oderDetails.Add(item);
            }
            else
            {
                var item = oderDetails.Where(x => x.ID == id).FirstOrDefault();
                if (item == null)
                {
                    var itemOrder = new BillSaleOrderModel
                    {
                        ID = id,
                        InvtID = invtId,
                        Qty = quantity,
                        SalesPrice = salePrice,
                        Discount = 0,
                        TaxAmtForInventory = tax,
                        AmountForInventory = amount,
                        UnitID = unitId,
                        OrderDiscForInvt = orderDisc
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
                    item.UnitID = unitId;
                    item.OrderDiscForInvt = orderDisc;
                }

            }
            Session["Order"] = oderDetails;
        }
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
                total += item.TaxAmtForInventory*item.SalesPrice;
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
        //Xoa di mat han da duoc chon
        public void DeteleAnInventory(int id)
        {
            var oderDetails = Session["Order"] as List<BillSaleOrderModel>;
            if (oderDetails != null)
            {
                var item = oderDetails.FirstOrDefault(x => x.ID == id);
                if (item != null)
                {
                    oderDetails.Remove(item);
                    Session["Order"] = oderDetails;
                }
            }
        }
        private PagedData<BillSaleOrderModel> GetPaginatedBill(int page)
        {
            var billOrderSales = new PagedData<BillSaleOrderModel>();
            var skipRecords = page * pageSize;
            var model = billSaleOrderService.GetListBill();
            int count = model.Count();
            var listOfBill = (from item in model
                              select new BillSaleOrderModel
                              {
                                  SOrderNo = item.SOrderNo,
                                  CustName = item.Customer.CustName,
                                  OrderDate = item.OrderDate,
                                  OverdueDate = item.OverdueDate,
                                  TaxAmt = item.TaxAmt,
                                  TotalAmt = item.TotalAmt,
                                  TypeName = item.InvoiceType.TypeName
                              }).Skip(skipRecords).Take(pageSize).ToList();
            billOrderSales.Data = listOfBill;
            billOrderSales.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            billOrderSales.Count = count;
            billOrderSales.PageSize = pageSize;
            billOrderSales.CurrentPage = page + 1;
            return billOrderSales;
        }
        public PagedData<BillSaleOrderModel> GetBillForListPage()
        {
            var listBill = new PagedData<BillSaleOrderModel>();
            var model = billSaleOrderService.GetListBill();
            int count = model.Count();
            var listOfBill = (from item in model
                                   select new BillSaleOrderModel
                                   {
                                       SOrderNo = item.SOrderNo,
                                       CustName = item.Customer.CustName,
                                       OrderDate =item.OrderDate,
                                       OverdueDate = item.OverdueDate,
                                       TaxAmt = item.TaxAmt,
                                       TotalAmt = item.TotalAmt,
                                       TypeName = item.InvoiceType.TypeName
                                   }).ToList();
            listBill.Data = listOfBill.Take(pageSize);
            listBill.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            listBill.CurrentPage = 1;
            listBill.Count = count;
            listBill.PageSize = pageSize;
            return listBill;
        }
        public BillSaleOrderModel GetBillById(int id)
        {
            var model = new BillSaleOrderModel();
            var billDetail = billSaleOrderService.GetBillById(id);
            model.SOrderNo = billDetail.SOrderNo;
            model.OrderDate = billDetail.OrderDate;
            model.OverdueDate = billDetail.OverdueDate;
            model.OrderDisc = billDetail.OrderDisc;
            model.TaxAmt = billDetail.TaxAmt;
            model.Description = billDetail.Description;
            return model;

        }
        public IEnumerable<BillSaleOrderModel> GetBillDetailById(int id)
        {
            
            var details = billSaleOrderService.GetBillDetailById(id);
            var model = from a in details
                        select new BillSaleOrderModel
                        {
                            InvtName = a.InvtName,
                            Qty = a.Qty,
                            SalesPrice = a.SalesPrice,
                            Discount = (decimal)a.Discount,
                            TaxAmt = a.TaxAmt,
                            Amount = a.Amount,
                            UnitName = a.UnitName,
                            OrderDiscForInvt = a.OrderDiscForInvt,
                        };
            return model;
        }
        #endregion
        #region Hien thi danh sach hoa don
        public ActionResult ListBillSaleOrder()
        {
            var listBill = GetBillForListPage();
            return View("ListBillSaleOrder", listBill);
        }
        /// <summary>
        /// Hien thi danh sach nhan vien dang LIST VIEW
        /// </summary>
        /// <returns></returns>
        public ActionResult ListBillView(int? page)
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
            return PartialView("ListBillSaleOrderParitalView", GetPaginatedBill(pageNumber));
        }
        #endregion
        #region Hien thi chi tiet hoa don
        public ActionResult DetailBill(int id)
        {
            var model = GetBillById(id);
            return PartialView("DetailBillSaleOrderPartialView", model);
        }
        public ActionResult ShowListInventoryOfBill(int id)
        {
            var model = GetBillDetailById(id);
            return PartialView("RowInventoryOfBillSaleOrderPartialView", model);
        }
        #endregion


    }
}
