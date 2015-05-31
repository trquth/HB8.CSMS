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
            var unitDetailL = new UnitDetail();
            var unitDetailT = new UnitDetail();
            model.InvtID = inventory.InvtID;
            model.InvtName = inventory.InvtName;
            model.QtyStock = inventory.QtyStock;
            model.SlsTax = inventory.SlsTax;
            model.Description = inventory.Description;
            model.StaffId = inventory.StaffId;
            model.StockID = inventory.StockID;
            model.ClassId = inventory.ClassId;
            model.StInventoryId = inventory.StInventoryId;
            model.SlsTax = inventory.SlsTax;
            model.Image = inventory.Image;

            //Luu MANY TO MANY 
            unitDetailL.UnitID = inventory.UnitID_L;
            unitDetailL.SalePrice = inventory.SalePrice_L;          
            unitDetailL.InvtID = inventory.InvtID;
            model.UnitDetails.Add(unitDetailL);

            unitDetailT.InvtID = inventory.InvtID;
            unitDetailT.UnitID = inventory.UnitID_T;
            unitDetailT.SalePrice = inventory.SalePrice_T;
            unitDetailT.UnitRate = inventory.UnitRate;
            model.UnitDetails.Add(unitDetailT);

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


        public InventoryDomain GetInventoryById(string id)
        {
            var model = context.Inventories.GetItemById(id);
            if (model ==null)
            {
                return null;
            }
            var inventory = new InventoryDomain();
            inventory.InvtID = model.InvtID;
            inventory.InvtName = model.InvtName;
            inventory.ClassName = model.Class.ClassName;
            inventory.QtyStock = model.QtyStock;
            inventory.SlsTax = model.SlsTax;
            inventory.Description = model.Description;
            inventory.StaffName = model.Staff.StaffName;
            inventory.Image = model.Image;
            inventory.StockName = model.Stock.StockName;
            var unitDetail = model.UnitDetails.Where(x => x.InvtID == id).ToArray();
            inventory.UnitName_L = unitDetail[0].Unit.UnitName;
            inventory.SalePrice_L = (decimal)unitDetail[0].SalePrice;
            inventory.UnitName_T = unitDetail[1].Unit.UnitName;
            inventory.SalePrice_T = (decimal)unitDetail[1].SalePrice;
            inventory.UnitRate = (int)unitDetail[1].UnitRate;
            inventory.StInvetoryName = model.StatusIventory.StInvetoryName;
            return inventory;

        }


        public List<Inventory> GetListInventory()
        {
            return context.Inventories.GetAllItem().ToList();
        }
    }
}
