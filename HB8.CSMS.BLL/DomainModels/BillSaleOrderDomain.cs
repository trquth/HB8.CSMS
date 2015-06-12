using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.DomainModels
{
    public class BillSaleOrderDomain
    {
        public int SOrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string InvoiceType { get; set; }
        public string CustID { get; set; }
        public Nullable<System.DateTime> OverdueDate { get; set; }
        public decimal OrderDisc { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TaxAmtForInventory { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public string StaffId { get; set; }
        public string InvtID { get; set; }
        public int Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountForInventory { get; set; }
        public int UnitID { get; set; }
        public decimal OrderDiscForInvt { get; set; }
        public string InvoiceID { get; set; }
    }
}
