using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.ConcreteFunctionsServer
{
    public class BillSaleOrderManagerService : IBillSaleOrderManagerService
    {
        private IDALContext context;
        public BillSaleOrderManagerService(IDALContext context)
        {
            this.context = context;
        }

        public IEnumerable<DAL.Models.Customer> GetListCustomers()
        {
            return context.Customers.GetAllItem();
        }

        public IEnumerable<DAL.Models.Stock> GetListStock()
        {
            return context.Stocks.GetAllItem().ToList();
        }

        public List<DAL.Models.Inventory> GetListInventory()
        {
            return context.Inventories.GetAllItem().ToList();
        }

        public List<DAL.Models.UnitDetail> GetUnitDetail()
        {
            return context.UnitDetails.GetAllItem().ToList();
        }

        public List<DAL.Models.UnitDetail> GetUnitDetailByID(string id)
        {
            return context.UnitDetails.GetAllItem().Where(x => x.InvtID == id).ToList();
        }

        public IEnumerable<DAL.Models.Staff> GetListStaff()
        {
            return context.Staffs.GetAllItem();
        }


        public int CreateBillSaleOrder(IEnumerable<DomainModels.BillSaleOrderDomain> inventory)
        {
            if (inventory != null)
            {
                try
                {
                    var model = new BillSaleOrder();
                    var item = inventory.FirstOrDefault();
                    model.OrderDate = DateTime.Now;
                    model.CustID = item.CustID;
                    model.OverdueDate = DateTime.Now;
                    model.OrderDisc = 12;
                    model.TaxAmt = 12;
                    model.TotalAmt = 12;
                    model.Payment = 12;
                    model.Debt = item.Debt;
                    model.Description = item.Description;
                    model.InvoiceID = "AB";
                    model.StaffID = item.StaffId;
                    //context.Orders.Create(model);
                    ////Luu MANY TO MANY 
                    //for (int i = 0; i < inventory.Count(); i++)
                    //{
                    //    var billOrderDetail = new BillSlsOrderDetail();
                    //    var itemDetail = inventory.ElementAt(i);
                    //    billOrderDetail.InvtID = itemDetail.InvtID;
                    //    billOrderDetail.Qty = itemDetail.Qty;
                    //    billOrderDetail.SalesPrice = itemDetail.SalesPrice;
                    //    billOrderDetail.Discount = itemDetail.Discount;
                    //    billOrderDetail.TaxAmt = item.TaxAmt;
                    //    billOrderDetail.Amount = item.Amount;
                    //    //billOrderDetail.UnitID = item.UnitID;
                    //    billOrderDetail.UnitName = "thung";
                    //    model.BillSlsOrderDetails.Add(billOrderDetail);
                    //}
                    context.Orders.Create(model);
                    context.Save();
                    return 1;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
             
            }
            else
            {
                return 0;
            }

        }
    }
}
