using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Class
    {
        public Class()
        {
            this.Inventories = new List<Inventory>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
