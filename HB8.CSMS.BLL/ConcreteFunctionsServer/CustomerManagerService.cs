using HB8.CSMS.BLL.Abstract;
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
            model.Overdue = customer.Overdue;
            model.Amount = customer.Amount;
            model.OverdueAmt = customer.OverdueAmt;
            model.DueAmt = customer.DueAmt;
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

        public DAL.Models.Staff GetCustomerById(string id)
        {
            return context.Staffs.GetItemById(id);
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
            model.Overdue = customer.Overdue;
            model.Amount = customer.Amount;
            model.OverdueAmt = customer.OverdueAmt;
            model.DueAmt = customer.DueAmt;
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
    }
}
