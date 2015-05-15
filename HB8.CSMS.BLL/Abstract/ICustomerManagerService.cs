using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
   public interface ICustomerManagerService
    {
       /// <summary>
       /// Luu thong tin cua khach hang
       /// </summary>
       /// <param name="staff"></param>
       /// <returns></returns>
        int CreateCustomer(CustomerDomain customer);
        /// <summary>
        /// Tra ve danh sach khach hang duoc sap xep
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetListCustomers();
        /// <summary>
        /// Tra ve tra ve thong tin khach hang dua vao ma khach hang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerDomain GetCustomerById(string id);
        /// <summary>
        /// Sua thong tin khach hang
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        int UpdateCustomer(CustomerDomain customer);
        /// <summary>
        /// Ham xoa thong tin nhan vien
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteCustomer(string id);
        /// <summary>
        /// Tra ve danh sach cac trang thai cua khach hang
        /// </summary>
        /// <returns></returns>
        List<Status> GetListStatus();
        //CustomerDomain GetNextCustomerTopList(string id, bool isHistoryBack);

    }
}
