using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HB8.CSMS.MVC.Models.Staff
{
    public class StaffModel
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string StaffName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}