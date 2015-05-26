using HB8.CSMS.BLL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.Abstract
{
    public interface IInventoryManagerService
    {
        /// <summary>
        /// Ham luu thong tin  san pham
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        int CreateInventory(InventoryDomain inventory);

    }
}
