using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Vendor
    {
        public string VendorID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public decimal DueAmt { get; set; }
        public decimal Amount { get; set; }
        public decimal OverdueAmt { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
