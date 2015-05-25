using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Unit
    {
        public Unit()
        {
            this.Inventories = new List<Inventory>();
        }

        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
