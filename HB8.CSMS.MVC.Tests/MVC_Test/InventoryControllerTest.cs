using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.ConcreteFunctionsServer;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.MVC.Tests.MVC_Test
{
    [TestFixture]
    class InventoryControllerTest
    {
        [Test]
        public void GetInventoryByIDTest()
        {
            IDALContext content = new DALContext();
            IInventoryManagerService context = new InventoryManagerService(content);
            var inventoryController = new InventoryManagerController(context);
            string  id = "ABCDE";
            var result = inventoryController.GetInventoryByID(id);
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetInventoryForListPageTest()
        {
            IDALContext content = new DALContext();
            IInventoryManagerService context = new InventoryManagerService(content);
            var inventoryController = new InventoryManagerController(context);
            var result = inventoryController.GetInventoryForListPage();
            Assert.IsNotNull(result);
        }
    }
}
