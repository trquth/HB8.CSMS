using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class StatusIventory
    {
        public StatusIventory()
        {
            this.Inventories = new List<Inventory>();
        }

        public string StInventoryId { get; set; }
        public string StInvetoryName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
