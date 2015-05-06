﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HB8.CSMS.MVC.Models.Staff
{
    public class StaffModel
    {
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        public string ID { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        public string StaffName { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string NumberPhone { get; set; }
        [Required(ErrorMessage = " Mail không được để trống")]
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}