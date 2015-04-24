using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class BillPurchaseOrder
    {
        public BillPurchaseOrder()
        {
            this.BillPurchaseOrdDetails = new List<BillPurchaseOrdDetail>();
        }

        public string POrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OrderType { get; set; }
        public Nullable<System.DateTime> OverdueDate { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal PromAmt { get; set; }
        public decimal ComAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public virtual ICollection<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
    }
}
