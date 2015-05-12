using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HB8.CSMS.MVC.Models.Customer
{
    public class CustomerModel
    {
        public string CustID { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Số ngày quá hạn thanh toán không được rỗng")]
        public int Overdue { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> OverdueAmt { get; set; }
        public Nullable<decimal> DueAmt { get; set; }
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Image { get; set; }
    }
}