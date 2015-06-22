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
        /// <summary>
        /// Tra ve danh sach hoa don
        /// </summary>
        /// <returns></returns>
        List<BillSaleOrder> GetListBill();
        /// <summary>
        /// Tra ve thong tin chi tiet hoa don
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BillSaleOrderDomain GetBillById(int id);
        /// <summary>
        /// Tra ve thong tin danh sach mat hang co trong hoa don
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<BillSaleOrderDomain> GetBillDetailById(int id);
        /// <summary>
        /// Xac nhan hoa don
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        int Confirm(int id);
        /// <summary>
        /// Huy hoa don
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        int Cancel(int id);
        /// <summary>
        /// Lay danh sach khach hang mua hang
        /// </summary>
        /// <returns></returns>
        IEnumerable<BillSaleOrderDomain> GetCustomerNames();
        /// <summary>
        /// Tong tien cho moi don hang cua tung khach hang
        /// </summary>
        /// <returns></returns>
        IEnumerable<BillSaleOrderDomain> TotalAmt();
        /// <summary>
        /// Lay ten khach hang va tong tien tren cac hoa don
        /// </summary>
        /// <returns></returns>
        IEnumerable<BillSaleOrderDomain> GetNameAndTotal();

    }
}
