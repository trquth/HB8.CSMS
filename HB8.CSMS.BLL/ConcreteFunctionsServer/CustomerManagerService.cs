using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.ConcreteFunctionsServer
{
    public class CustomerManagerService : ICustomerManagerService
    {
        public IDALContext context;
        public CustomerManagerService(IDALContext context)
        {
            this.context = context;
        }
        public int CreateCustomer(DomainModels.CustomerDomain customer)
        {
            var model = new Customer();
            model.CustID = customer.CustID;
            model.CustName = customer.CustName;
            model.Address = customer.Address;
            model.Phone = customer.Phone;
            model.Fax = customer.Fax;
            model.Email = customer.Email;         
            model.StatusId = customer.StatusID;
            model.Description = customer.Description;
            model.BirthDate = customer.BirthDate;
            model.CreateDate = customer.CreateDate;
            context.Customers.Create(model);
            context.Save();
            return 0;
        }

        public IEnumerable<DAL.Models.Customer> GetListCustomers()
        {
            return context.Customers.GetAllItem();
        }
        public int UpdateCustomer(DomainModels.CustomerDomain customer)
        {
            var model = context.Customers.GetItemById(customer.CustID);
            if (customer.Image != null)//kiem tra mot tam hinh neu ma khong co thay doi
            {
                model.Image = customer.Image;
            }
            model.CustName = customer.CustName;
            model.Address = customer.Address;
            model.Phone = customer.Phone;
            model.Fax = customer.Fax;
            model.Email = customer.Email;
            model.Status = model.Status;
            model.Description = model.Description;
            model.BirthDate = model.BirthDate;
            model.CreateDate = model.CreateDate;
            context.Customers.Update(model);
            context.Save();
            return 0;
        }

        public int DeleteCustomer(string id)
        {
            var model = context.Customers.GetItemById(id);
            context.Customers.Delete(model);
            context.Save();
            return 0;
        }
        public List<Status> GetListStatus()
        {
            return context.Status.GetAllItem().ToList();
        }
        #region Ghi chu
        /// <summary>
        /// Lay ra nguoi khach hang tiep theo de show
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isHistoryBack"></param>
        /// <returns></returns>
      
        //public DomainModels.CustomerDomain GetNextCustomerTopList(string id, bool isHistoryBack)
        //{
        //    var model = new CustomerDomain();
        //    if (isHistoryBack)
        //    {
        //        var customer = context.Customers.GetItemById(id);
        //        model.Image = customer.Image;
        //        model.CustName = customer.CustName;
        //        model.Address = customer.Address;
        //        model.Phone = customer.Phone;
        //        return model;
        //    }
        //    else
        //    {
        //        return model;
        //    }
        //}

        #endregion
        CustomerDomain ICustomerManagerService.GetCustomerById(string id)
        {
            var model = context.Customers.GetItemById(id);
            var customer = new CustomerDomain();
            customer.Image = model.Image;
            customer.CustID = model.CustID;
            customer.CustName = model.CustName;
            customer.Address = model.Address;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            customer.Email = model.Email;
            customer.Overdue = model.Overdue;
            customer.Amount = model.Amount;
            customer.OverdueAmt = model.OverdueAmt;
            customer.DueAmt = model.DueAmt;
            customer.StatusID = model.StatusId;
            customer.Description = model.Description;
            customer.BirthDate = model.BirthDate;
            customer.CreateDate = model.CreateDate;
            return customer;
        }
        public int ReturnIndexCustomer(string id)
        {
            var model = context.Customers.GetAllItem();
            int count = 1;
            foreach (var item in model)
            {
                if (item.CustID.Equals(id))
                    break;
                count++;

            }
            return count;
        }
    }
}
