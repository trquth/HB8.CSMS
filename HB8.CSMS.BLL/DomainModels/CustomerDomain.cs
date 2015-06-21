using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.DomainModels
{
    public class CustomerDomain
    {
        public CustomerDomain() { }
        public CustomerDomain(string id, string name, string address, string phone, string email, string statusID, string description,string image)
        {
            CustID = id;
            CustName = name;
            Address = address;
            Phone = phone;
            Email = email;
            StatusID = statusID;
            Description = description;
            Image = image;
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
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Image { get; set; }
    }
}
