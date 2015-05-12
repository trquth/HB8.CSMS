using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            this.Customers = new List<Customer>();
        }

        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
