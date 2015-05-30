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
            this.UnitDetails = new List<UnitDetail>();
        }

        public string InvtID { get; set; }
        public string InvtName { get; set; }
        public int ClassId { get; set; }
        public Nullable<int> UnitID { get; set; }
        public int QtyStock { get; set; }
        public decimal SlsTax { get; set; }
        public string StInventoryId { get; set; }
        public string Description { get; set; }
        public string StaffId { get; set; }
        public string StockID { get; set; }
        public virtual ICollection<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
        public virtual ICollection<BillSlsOrderDetail> BillSlsOrderDetails { get; set; }
        public virtual Class Class { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual StatusIventory StatusIventory { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ICollection<StockRequisitionDetail> StockRequisitionDetails { get; set; }
        public virtual ICollection<UnitDetail> UnitDetails { get; set; }
    }
}
