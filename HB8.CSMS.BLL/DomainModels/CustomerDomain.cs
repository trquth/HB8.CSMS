using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.DomainModels
{
    public class CustomerDomain
    {
        public CustomerDomain(string id, string name, string address, string phone, string fax, string email, int overDue, decimal? amount, decimal? overDueAmt, decimal? dueAmt, string statusID, string description, DateTime? birthDate, DateTime? createDate, string image)
        {
            CustID = id;
            CustName = name;
            Address = name;
            Phone = phone;
            Fax = fax;
            Email = email;
            Overdue = overDue;
            Amount = amount;
            Overdue = overDue;
            Amount = amount;
            OverdueAmt = overDueAmt;
            DueAmt = dueAmt;
            StatusID = statusID;
            Description = description;
            BirthDate = birthDate;
            CreateDate = createDate;
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
