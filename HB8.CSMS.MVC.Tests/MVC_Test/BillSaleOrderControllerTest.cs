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
    class BillSaleOrderControllerTest
    {
        [Test]
        public void GetBillDetailByIdTest()
        {
            IDALContext content = new DALContext();
            IBillSaleOrderManagerService context = new BillSaleOrderManagerService(content);
            var inventoryController = new BillSaleOrderManagerController(context);
            int id = 9;
            var result = inventoryController.GetBillDetailById(id);
            Assert.IsNotNull(result);
        }
    }
}
