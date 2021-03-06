﻿using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.DBContext
{
    public interface IDALContext : IUnitOfWork
    {
        IStaffRepository Staffs { get; }
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        IStatusRepository Status { get; }
        IInventoryRepository Inventories { get; }
        IUnitRepository Units { get; }
        IClassRepository Classes { get; }
        IStatusInventroyRepository StatusInvetories { get; }
        IUnitDetailRepository UnitDetails { get; }
        IStockRepository Stocks { get; }
        IBillSaleOrderRepository Orders { get; }
        IBillSlsOrderDetailRepository OrderDetails { get; }
    }
}
