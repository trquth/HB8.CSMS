using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.UoW
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
