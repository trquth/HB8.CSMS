using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class InvoiceType
    {
        public InvoiceType()
        {
            this.BillSaleOrders = new List<BillSaleOrder>();
        }

        public string InvoiceType1 { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<BillSaleOrder> BillSaleOrders { get; set; }
    }
}
