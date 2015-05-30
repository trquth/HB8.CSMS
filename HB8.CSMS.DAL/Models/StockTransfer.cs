using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class StockTransfer
    {
        public StockTransfer()
        {
            this.StkTransDetails = new List<StkTransDetail>();
        }

        public string TransID { get; set; }
        public System.DateTime TransDate { get; set; }
        public string FromStockID { get; set; }
        public string ToStockID { get; set; }
        public decimal TotalAmt { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StkTransDetail> StkTransDetails { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
