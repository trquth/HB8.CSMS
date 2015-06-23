using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.ConcreteFunctionsServer;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.MVC.Controllers;
using HB8.CSMS.MVC.Models.Staff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace HB8.CSMS.MVC.Tests.MVC_Test
{
    [TestFixture]
    class StaffControllerTest
    {
        [Test]
        public void EncryptTest()
        {
            string pass = "123";
            string passMD5 = StaffManagerController.Encrypt(pass, true);
            Assert.AreNotEqual(pass, passMD5);
        }
        [Test]
        public void FindPreviousIDTest()
        {

        }
        [Test]
        public void IndexTest()
        {
            IDALContext content = new DALContext();
            IStaffManagerService context = new StaffManagerService(content);
            string expectView = "IndexPartialView";
            var staffController = new StaffManagerController(context);
            var result = staffController.Index() as PartialViewResult;
            Assert.AreEqual(expectView, result.ViewName);
        }
        [Test]
        public void GetStaffByStaffId()
        {
            IDALContext content = new DALContext();
            IStaffManagerService context = new StaffManagerService(content);
            var staffController = new StaffManagerController(context);
            string id = "ABC10";
            StaffModel result = staffController.GetStaffByStaffId(id);
            Assert.IsNotNull(result);
        }
    }
}
