using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Staff
    {
        public Staff()
        {
            this.BillPurchaseOrdDetails = new List<BillPurchaseOrdDetail>();
            this.BillSaleOrders = new List<BillSaleOrder>();
            this.Inventories = new List<Inventory>();
            this.StockRequisitions = new List<StockRequisition>();
        }

        public string StaffID { get; set; }
        public string UserId { get; set; }
        public string StaffName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Password { get; set; }
        public Nullable<int> Deleted { get; set; }
        public virtual ICollection<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
        public virtual ICollection<BillSaleOrder> BillSaleOrders { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<StockRequisition> StockRequisitions { get; set; }
    }
}
