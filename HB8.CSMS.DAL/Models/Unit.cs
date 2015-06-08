using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Unit
    {
        public Unit()
        {
            this.BillSlsOrderDetails = new List<BillSlsOrderDetail>();
            this.UnitDetails = new List<UnitDetail>();
        }

        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> UnitClassId { get; set; }
        public virtual ICollection<BillSlsOrderDetail> BillSlsOrderDetails { get; set; }
        public virtual UnitClass UnitClass { get; set; }
        public virtual ICollection<UnitDetail> UnitDetails { get; set; }
    }
}
