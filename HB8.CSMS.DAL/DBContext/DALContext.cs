using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.ConcreteFunctions;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.DBContext
{
    public class DALContext : IDALContext
    {
        private CSMSContext dbContext;
        private IStaffRepository staffs;
        private IUserRepository users;
        private ICustomerRepository customers;
        private IStatusRepository status;
        private IInventoryRepository inventories;
        private IUnitRepository units;
        private IClassRepository classes;
        private IStatusInventroyRepository statusInventories;
        public DALContext()
        {
            dbContext = new CSMSContext();
        }
        public IStaffRepository Staffs
        {
            get
            {
                if (staffs == null)
                {
                    staffs = new StaffRepository(dbContext);
                }
                return staffs;
            }
        }

        public int Save()
        {
            dbContext.SaveChanges();
            return 1;
        }


        public IUserRepository Users
        {
            get
            {
                if (users == null)
                {
                    users = new UserRepository(dbContext);
                }
                return users;
            }
        }


        public ICustomerRepository Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = new CustomerRepository(dbContext);
                }
                return customers;
            }
        }


        public IStatusRepository Status
        {
            get
            {
                if (status == null)
                {
                    status = new StatusRepository(dbContext);
                }
                return status;
            }
        }
        public IInventoryRepository Inventories
        {
            get
            {
                if (inventories == null)
                {
                    inventories = new InventoryRepository(dbContext);
                }
                return inventories;
            }
        }


        public IUnitRepository Units
        {
            get
            {
                if (units == null)
                {
                    units = new UnitRepository(dbContext);
                }
                return units;
            }
        }


        public IClassRepository Classes
        {
            get
            {
                if (classes == null)
                {
                    classes = new ClassRepository(dbContext);
                }
                return classes;
            }
        }


        public IStatusInventroyRepository StatusInvetories
        {
            get 
            {
                if (statusInventories == null)
                {
                    statusInventories = new StatusInventoryRepository(dbContext);
                }
                return statusInventories;
            }
        }
    }
}
