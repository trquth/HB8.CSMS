using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
    public interface IBillSaleOrderManagerService
    {
        /// <summary>
        /// Tra ve danh sach khach hang duoc sap xep
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetListCustomers();
        /// <summary>
        /// Tra ve danh sach kho hang
        /// </summary>
        /// <returns></returns>
        IEnumerable<Stock> GetListStock();
        /// <summary>
        /// Tra ve danh sach san pham
        /// </summary>
        /// <returns></returns>
        List<Inventory> GetListInventory();
        /// <summary>
        /// Tra ve danh sach don vi tinh
        /// </summary>
        /// <returns></returns>
        List<UnitDetail> GetUnitDetailByID(string id);
        /// <summary>
        /// Tra ve danh sach nhan vien duoc sap xep
        /// </summary>
        /// <returns></returns>
        IEnumerable<Staff> GetListStaff();
        /// <summary>
        /// Ham luu thong tin hoa don
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        int CreateBillSaleOrder(IEnumerable<BillSaleOrderDomain> inventory);
        
    }
}
