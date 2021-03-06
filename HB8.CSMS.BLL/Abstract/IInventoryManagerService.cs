﻿using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
    public interface IInventoryManagerService
    {
        /// <summary>
        /// Ham luu thong tin  san pham
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        int CreateInventory(InventoryDomain inventory);
        /// <summary>
        /// Tra ve danh sach nhom san pham
        /// </summary>
        /// <returns></returns>
        List<Class> GetListInventoryClass();
        /// <summary>
        /// Tra ve danh don vi tinh UNIT cho thung
        /// </summary>
        /// <returns></returns>
        List<Unit> GetUnitForT();
        /// <summary>
        /// Tra ve danh don vi tinh UNIT cho le
        /// </summary>
        /// <returns></returns>
        List<Unit> GetUnitForL();
        /// <summary>
        /// Tra ve trang thai cua san pham
        /// </summary>
        /// <returns></returns>
        List<StatusIventory> GetStatusForInventory();
        /// <summary>
        /// Tra ve danh sach nhan vien
        /// </summary>
        /// <returns></returns>
        List<Staff> GetListStaff();
        /// <summary>
        /// Tra ve danh sach kho hang
        /// </summary>
        /// <returns></returns>
        List<Stock> GetListStock();
        /// <summary>
        /// Tra ve thong tin chi tiet cua san pham
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryDomain GetInventoryById(string id);
        /// <summary>
        /// Tra ve danh sach san pham
        /// </summary>
        /// <returns></returns>
        List<Inventory> GetListInventory();
        /// <summary>
        /// Sua thong tin san pham
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        int UpdateInventory(InventoryDomain inventory);
        /// <summary>
        /// Tra ve so thu tu cua san pham  trong database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ReturnIndexInventory(string id);
        /// <summary>
        /// Ham xoa thong tin san pham
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteInventory(string id);
        /// <summary>
        /// Tam xoa thong tin cua san pham
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteInventoryIfInventoryExit(string id);
       

    }
}
