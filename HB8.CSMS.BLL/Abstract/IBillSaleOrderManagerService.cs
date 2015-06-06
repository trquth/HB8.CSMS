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
    }
}
