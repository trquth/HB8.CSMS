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
    public class InventoryManagerService : IInventoryManagerService
    {
        private IDALContext context;
        public InventoryManagerService(IDALContext context)
        {
            this.context = context;
        }
        public int CreateInventory(DomainModels.InventoryDomain inventory)
        {
            var model = new Inventory();
            var unitDetail = new UnitDetail();
            model.InvtID = inventory.InvtID;
            model.InvtName = inventory.InvtName;
            model.QtyStock = inventory.QtyStock;
            model.SlsTax = inventory.SlsTax;
            model.Description = inventory.Description;
            model.StaffId = inventory.StaffId;
            model.StockID = inventory.StockID;
            model.ClassId = inventory.ClassId;
            unitDetail.InvtID = inventory.InvtID;
            unitDetail.UnitID = inventory.UnitID;
            unitDetail.SalePrice = inventory.SalePrice_L;
            unitDetail.SalePrice = inventory.SalePrice_T;
            unitDetail.UnitRate = inventory.UnitRate;
            context.UnitDetails.Create(unitDetail);
            context.Inventories.Create(model);
            context.Save();
            return 0;
        }


        public List<Class> GetListInventoryClass()
        {
            return context.Classes.GetAllItem().ToList();
        }


        public List<Unit> GetUnitForT()
        {
            return context.Units.GetAllItem().Where(x => x.UnitClassId == 1).ToList();
        }

        public List<Unit> GetUnitForL()
        {
            return context.Units.GetAllItem().Where(x => x.UnitClassId == 2).ToList();
        }

        List<StatusIventory> IInventoryManagerService.GetStatusForInventory()
        {
            return context.StatusInvetories.GetAllItem().ToList();
        }
        public List<Staff> GetListStaff()
        {
            return context.Staffs.GetAllItem().ToList();
        }


        public List<Stock> GetListStock()
        {
            return context.Stocks.GetAllItem().ToList();
        }
    }
}
