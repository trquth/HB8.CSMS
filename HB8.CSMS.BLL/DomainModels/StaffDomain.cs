using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.DomainModels
{
    public class StaffDomain
    {
        public StaffDomain() { }
        public StaffDomain(string id, string userId, string staffName, string image, string address, string numberPhone, string email, string confirmPass)
        {
            ID = id;
            UserId = userId;
            StaffName = staffName;
            Address = address;
            NumberPhone = numberPhone;
            Email = email;
            Image = image;
            Password = confirmPass;
        }
        public string ID { get; set; }
        public string UserId { get; set; }
        public string StaffName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> Deleted { get; set; }
    }
}
