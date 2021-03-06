﻿using HB8.CSMS.BLL.DomainModels;
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
        /// Ham luu thong tin nhan vien
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        int CreateStaff(StaffDomain staff);
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
        /// <summary>
        /// Sua thong tin nhan vien
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        int UpdateStaff(StaffDomain staff);
        /// <summary>
        /// Ham xoa thong tin nhan vien
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteStaff(string id);
        /// <summary>
        /// Tra ve so thu tu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ReturnIndexStaff(string id);
        /// <summary>
        /// Tam xoa thong tin cua nhan vien do di
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteStaffIfStaffExit(string id);
    }
}
