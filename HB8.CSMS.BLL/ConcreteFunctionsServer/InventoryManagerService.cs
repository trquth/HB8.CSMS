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
            if (model == null)
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
            var unitDetailT = model.UnitDetails.Where(x => x.InvtID == id && x.UnitRate != null).First();
            var unitDetailL = model.UnitDetails.Where(x => x.InvtID == id && x.UnitRate == null).First();
            inventory.UnitName_L = unitDetailL.Unit.UnitName;
            inventory.UnitName_T = unitDetailL.Unit.UnitName;
            inventory.SalePrice_L = (decimal)unitDetailL.SalePrice;
            inventory.SalePrice_T = (decimal)unitDetailT.SalePrice;
            inventory.UnitRate = (int)unitDetailT.UnitRate;
            inventory.StInvetoryName = model.StatusIventory.StInvetoryName;
            inventory.Image = model.Image;
            return inventory;

        }


        public List<Inventory> GetListInventory()
        {
            return context.Inventories.GetAllItem().ToList();
        }


        public int UpdateInventory(InventoryDomain inventory)
        {
            var model = context.Inventories.GetItemById(inventory.InvtID);
            if (inventory.Image != null)//kiem tra mot tam hinh neu ma khong co thay doi
            {
                model.Image = inventory.Image;
            }

            var unitDetailL = new UnitDetail();
            var unitDetailT = new UnitDetail();
            model.UnitDetails.Clear();
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

            context.Inventories.Update(model);
            context.Save();
            return 0;
        }
        public int ReturnIndexInventory(string id)
        {
            var model = context.Inventories.GetAllItem();
            int count = 1;
            foreach (var item in model)
            {
                if (item.InvtID.Equals(id))
                    break;
                count++;
	
            }
            return count;
        }
    }
}
