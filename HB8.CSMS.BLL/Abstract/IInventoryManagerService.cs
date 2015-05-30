using HB8.CSMS.BLL.DomainModels;
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

    }
}
