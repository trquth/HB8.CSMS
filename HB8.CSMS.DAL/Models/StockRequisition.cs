using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class StockRequisition
    {
        public StockRequisition()
        {
            this.StockRequisitionDetails = new List<StockRequisitionDetail>();
        }

        public string OutStockID { get; set; }
        public string StaffID { get; set; }
        public string StockID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal SubTotal { get; set; }
        public string Note { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ICollection<StockRequisitionDetail> StockRequisitionDetails { get; set; }
    }
}
