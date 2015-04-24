using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class StockRequisitionDetail
    {
        public string OutStockID { get; set; }
        public string InvtID { get; set; }
        public int QtyOutStock { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual StockRequisition StockRequisition { get; set; }
    }
}
