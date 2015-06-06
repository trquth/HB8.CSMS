using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.ConcreteFunctionsServer
{
    public class BillSaleOrderManagerService : IBillSaleOrderManagerService
    {
        private IDALContext context;
        public BillSaleOrderManagerService(IDALContext context)
        {
            this.context = context;
        }

        public IEnumerable<DAL.Models.Customer> GetListCustomers()
        {
            return context.Customers.GetAllItem();
        }


        public IEnumerable<DAL.Models.Stock> GetListStock()
        {
            return context.Stocks.GetAllItem().ToList();
        }
    }
}
