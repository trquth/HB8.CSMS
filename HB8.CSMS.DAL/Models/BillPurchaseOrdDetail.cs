using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class BillPurchaseOrdDetail
    {
        public string POrderNo { get; set; }
        public string StaffId { get; set; }
        public string InvtID { get; set; }
        public int Qty { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public string StockID { get; set; }
        public int QtyProm { get; set; }
        public decimal QtyPromAmt { get; set; }
        public decimal AmtProm { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Amount { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual BillPurchaseOrder BillPurchaseOrder { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
