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
    class CustomerControllerTest
    {
        [Test]
        public void GetCustomerForListPageTest()
        {
            IDALContext content = new DALContext();
            ICustomerManagerService context = new CustomerManagerService(content);
            var staffController = new CustomerManagerController(context);
            var result = staffController.GetCustomerForListPage();
            Assert.IsNotNull(result);
        }
        [Test]
        public void FindNextID()
        {
            IDALContext content = new DALContext();
            ICustomerManagerService context = new CustomerManagerService(content);
            var staffController = new CustomerManagerController(context);
            string id="abcdef01";
            var result = staffController.FindNextID(id);
            Assert.AreEqual("abcdef02",result);
        }
        [Test]
        public void FindPreviousID()
        {
            IDALContext content = new DALContext();
            ICustomerManagerService context = new CustomerManagerService(content);
            var staffController = new CustomerManagerController(context);
            string id = "abcdef02";
            var result = staffController.FindPreviousID(id);
            Assert.AreEqual("abcdef01", result);
        }
    }
}
