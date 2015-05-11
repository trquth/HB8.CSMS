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
        public Nullable<int> Overdue { get; set; }
        public decimal Amount { get; set; }
        public decimal OverdueAmt { get; set; }
        public decimal DueAmt { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public virtual ICollection<BillSaleOrder> BillSaleOrders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
