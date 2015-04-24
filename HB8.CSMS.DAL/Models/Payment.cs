using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentNo { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal PaymentAmt { get; set; }
        public string CustID { get; set; }
        public string SalesPersonID { get; set; }
        public string Description { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
