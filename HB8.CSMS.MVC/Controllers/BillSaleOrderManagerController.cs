using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HB8.CSMS.MVC.Models.BillSaleOrder;

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
        
        #endregion
        #region Show Row 
      
        #endregion
        public ActionResult ListBillSaleOrder()
        {
            return View();
        }

    }
}
