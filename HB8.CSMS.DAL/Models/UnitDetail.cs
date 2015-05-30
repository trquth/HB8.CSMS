using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class UnitDetail
    {
        public int UnitID { get; set; }
        public string InvtID { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<int> UnitRate { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
