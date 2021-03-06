using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.BillSaleOrders = new List<BillSaleOrder>();
            this.Payments = new List<Payment>();
        }

        public string CustID { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int Overdue { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> OverdueAmt { get; set; }
        public Nullable<decimal> DueAmt { get; set; }
        public string StatusId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Image { get; set; }
        public virtual ICollection<BillSaleOrder> BillSaleOrders { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
