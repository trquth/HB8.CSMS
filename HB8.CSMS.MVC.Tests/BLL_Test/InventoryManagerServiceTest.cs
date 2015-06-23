using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.ConcreteFunctionsServer;
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.MVC.Tests.BLL_Test
{
    [TestFixture]
    class InventoryManagerServiceTest
    {
        [Test]
        public void CreateInventoryTest()
        {
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.CreateInventory(It.IsAny<InventoryDomain>())).Returns(0);
            var inventory = new InventoryDomain
            {
                InvtID = "ABCDE1",
                InvtName = "Bánh mì E",
                ClassId = 1,
                QtyStock = 123,
                SlsTax = 0,
                StInventoryId = "AV",
                StaffId = "ABC21",
            };
            int i = fakeObject.Object.CreateInventory(inventory);
            Assert.AreEqual(0, i);
        }
        [Test]
        public void GetListInventoryClassTest()
        {
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.GetListInventoryClass()).Returns(() => new List<Class> {
                new Class(){ClassId=1,ClassName="Bánh kẹo"},new Class(){ClassId=1,ClassName="Nước giải khát"}});
            var result = fakeObject.Object.GetListInventoryClass();
            Object.Equals(
               new List<Class> {
                new Class(){ClassId=1,ClassName="Bánh kẹo"},new Class(){ClassId=1,ClassName="Nước giải khát"}}, result);
        }
        [Test]
        public void GetUnitForTTest()
        {
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.GetUnitForT()).Returns(() => new List<Unit> {
                new Unit(){UnitID=1,UnitName="Thùng",UnitClassId=1},new Unit(){UnitID=2,UnitName="Gói",UnitClassId=2}});
            var result = fakeObject.Object.GetUnitForT();
            Object.Equals(
               new List<Unit> {
                new Unit(){UnitID=1,UnitName="Thùng",UnitClassId=1},new Unit(){UnitID=2,UnitName="Gói",UnitClassId=2}}, result);
        }
        [Test]
        public void GetInventoryByIdTest()
        {
            string id = "abcdef02";
            var inventory = new Inventory
            {
                InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            };
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.GetInventoryById(It.IsAny<string>())).Returns(() => new InventoryDomain
            {
                InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            });
            var result = fakeObject.Object.GetInventoryById(id);
            Object.Equals(result, new InventoryDomain
            {
                InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            });
        }
        [Test]
        public void UpdateInventoryTest()
        {
            var data = new[] 
            {
                new Inventory
            {
                   InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            },
            new Inventory
            {
                    InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            }
            };
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.UpdateInventory(It.IsAny<InventoryDomain>())).Returns(0);
            var editInventory= new InventoryDomain
            {
                InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            };
            int result = fakeObject.Object.UpdateInventory(editInventory);
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void ReturnIndexInventoryTest()
        {
            var data = new[] 
            {
                new Inventory
            {
                   InvtID = "ABCDE",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            },
            new Inventory
            {
                    InvtID = "ABCD1",
                InvtName = "Bánh mì A",
                ClassId = 1,
                QtyStock = 123,
                StInventoryId = "AV",
                StaffId = "abc21",
                StockID = "K01"
            }
            };
            string id = "ABCD1";
            var fakeObject = new Mock<IInventoryManagerService>();
            fakeObject.Setup(x => x.ReturnIndexInventory(It.IsAny<string>())).Returns(2);
            int result = fakeObject.Object.ReturnIndexInventory(id);
            Assert.AreEqual(2, result);
        }
    }
}
