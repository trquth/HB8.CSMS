using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class StkTransDetail
    {
        public string TransID { get; set; }
        public string InvtID { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public virtual StockTransfer StockTransfer { get; set; }
    }
}
