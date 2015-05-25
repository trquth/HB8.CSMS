using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            this.BillPurchaseOrdDetails = new List<BillPurchaseOrdDetail>();
            this.BillSlsOrderDetails = new List<BillSlsOrderDetail>();
            this.StockRequisitionDetails = new List<StockRequisitionDetail>();
        }

        public string InvtID { get; set; }
        public string InvtName { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> UnitRate { get; set; }
        public decimal SalesPriceT { get; set; }
        public decimal SalesPriceL { get; set; }
        public int QtyStock { get; set; }
        public decimal SlsTax { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
        public virtual ICollection<BillSlsOrderDetail> BillSlsOrderDetails { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<StockRequisitionDetail> StockRequisitionDetails { get; set; }
    }
}
