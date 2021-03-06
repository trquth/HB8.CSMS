using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Stock
    {
        public Stock()
        {
            this.BillPurchaseOrdDetails = new List<BillPurchaseOrdDetail>();
            this.Inventories = new List<Inventory>();
            this.StockRequisitions = new List<StockRequisition>();
            this.StockTransfers = new List<StockTransfer>();
        }

        public string StockID { get; set; }
        public string StockName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<StockRequisition> StockRequisitions { get; set; }
        public virtual ICollection<StockTransfer> StockTransfers { get; set; }
    }
}
