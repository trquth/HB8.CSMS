using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.DomainModels;
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
                    model.OrderDate = item.OrderDate;
                    model.CustID = item.CustID;
                    model.OverdueDate = item.OverdueDate;
                    model.OrderDisc = item.OrderDisc;
                    model.TaxAmt = item.TaxAmt;
                    model.TotalAmt = item.TotalAmt;
                    model.Payment = item.Payment;
                    model.Debt = item.Debt;
                    model.Description = item.Description;
                    model.InvoiceID = item.InvoiceID;
                    model.StaffID = item.StaffId;

                    //Luu MANY TO MANY 
                    for (int i = 0; i < inventory.Count(); i++)
                    {
                        var billOrderDetail = new BillSlsOrderDetail();
                        var itemDetail = inventory.ElementAt(i);
                        billOrderDetail.InvtID = itemDetail.InvtID;
                        billOrderDetail.Qty = itemDetail.Qty;
                        billOrderDetail.SalesPrice = itemDetail.SalesPrice;
                        billOrderDetail.Discount = itemDetail.Discount;
                        billOrderDetail.TaxAmt = item.TaxAmt;
                        billOrderDetail.Amount = item.Amount;
                        billOrderDetail.UnitId = item.UnitID;
                        billOrderDetail.OrderDiscForInvt = item.OrderDiscForInvt;
                        model.BillSlsOrderDetails.Add(billOrderDetail);
                    }
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
        public List<BillSaleOrder> GetListBill()
        {
            return context.Orders.GetAllItem().ToList();
        }     
        BillSaleOrderDomain IBillSaleOrderManagerService.GetBillById(int id)
        {
            var billDetail = context.Orders.GetItemByIdWithIntType(id);
            var model = new BillSaleOrderDomain();
            model.SOrderNo = billDetail.SOrderNo;
            model.CustName = billDetail.Customer.CustName;
            model.StaffName = billDetail.Staff.StaffName;
            model.OrderDate = billDetail.OrderDate;
            model.OverdueDate = billDetail.OverdueDate;
            model.OrderDisc = billDetail.OrderDisc;
            model.TaxAmt = billDetail.TaxAmt;
            model.Description = billDetail.Description;
            return model;
        }


        public IEnumerable<BillSaleOrderDomain> GetBillDetailById(int id)
        {
            var items = context.OrderDetails.GetAllItem().Where(x=>x.SOrderNo ==id);
            var model = from a in items
                        select new BillSaleOrderDomain
                        {
                            InvtName = a.Inventory.InvtName,
                            Qty = a.Qty,
                            SalesPrice = a.SalesPrice,
                            Discount = (decimal)a.Discount,
                            TaxAmt = a.TaxAmt,
                            Amount = a.Amount,
                            UnitName = a.Unit.UnitName,
                            OrderDiscForInvt = a.OrderDiscForInvt,
                        };
            return model;
        }
    }
}
