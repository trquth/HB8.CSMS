using HB8.CSMS.DAL.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
    public interface IStaffManagerService<T> where T:class
    {
        IQueryable<T> GetListPosition();
    }
}
