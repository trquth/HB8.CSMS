using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class BillSlsOrderDetail
    {
        public int ID { get; set; }
        public string StaffId { get; set; }
        public string SOrderNo { get; set; }
        public string InvtID { get; set; }
        public int Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Amount { get; set; }
        public virtual BillSaleOrder BillSaleOrder { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
