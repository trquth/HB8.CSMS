using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
    public interface IStaffManagerService
    {
        /// <summary>
        /// Tra ve danh sach chu vu cua nhan vien
        /// </summary>
        /// <returns></returns>
        List<User> GetListPosition();
        /// <summary>
        /// Ham tao va luu nhan vien moi vao DATABASE
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        Staff CreateStaff(Staff staff);
        /// <summary>
        /// Tra ve danh sach nhan vien duoc sap xep
        /// </summary>
        /// <returns></returns>
        IEnumerable<Staff> GetListStaff();
        /// <summary>
        /// Tra ve danh sach nhan vien dua vao ma nv
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Staff GetStaffById(string id);
    }
}
