using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HB8.CSMS.MVC4.Models.Staff
{
    public class StaffModel
    {
        [Required(ErrorMessage = "Mã nhân viên không được rỗng.")]
        [StringLength(5, ErrorMessage = "Mã nhân viên không được quá 5 kí tự.")]
        public string ID { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Tên nhân viên không được rỗng.")]
        [StringLength(50, ErrorMessage = "Tên nhân viên không được quá 50 kí tự.")]
        public string StaffName { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Địa chỉ  không được rỗng.")]
        public string Address { get; set; }
        [Phone(ErrorMessage = "Số điện thoại không được rỗng.")]
        public string NumberPhone { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }
        public string UserName { get; set; }

    }
}