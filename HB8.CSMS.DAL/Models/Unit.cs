using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Unit
    {
        public Unit()
        {
            this.UnitDetails = new List<UnitDetail>();
        }

        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> UnitClassId { get; set; }
        public virtual UnitClass UnitClass { get; set; }
        public virtual ICollection<UnitDetail> UnitDetails { get; set; }
    }
}
