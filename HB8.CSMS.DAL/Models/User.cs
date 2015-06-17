using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class User
    {
        public User()
        {
            this.Staffs = new List<Staff>();
        }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
