using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class BillSaleOrder
    {
        public BillSaleOrder()
        {
            this.BillSlsOrderDetails = new List<BillSlsOrderDetail>();
        }

        public string SOrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string InvoiceType { get; set; }
        public string CustID { get; set; }
        public Nullable<System.DateTime> OverdueDate { get; set; }
        public decimal OrderDisc { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
        public string Description { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual InvoiceType InvoiceType1 { get; set; }
        public virtual ICollection<BillSlsOrderDetail> BillSlsOrderDetails { get; set; }
    }
}
