using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.DomainModels;
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
    public class BillSaleOrderManagerServiceTest
    {
        [Test]
        public void CreateBillSaleOrderTest()
        {
            var fakeObject = new Mock<IBillSaleOrderManagerService>();
            fakeObject.Setup(x => x.CreateBillSaleOrder(It.IsAny<List<BillSaleOrderDomain>>())).Returns(1);
            var bill = new List<BillSaleOrderDomain>
            {
                new BillSaleOrderDomain
                {
                    CustID="abcdef01",
                    OrderDisc =0,
                    TaxAmt=5,
                    TotalAmt=10,
                    InvoiceID="XY"
},
            };
            int i = fakeObject.Object.CreateBillSaleOrder(bill);
            Assert.AreEqual(1, i);
        }
        [Test]
        public void ConfirmTest()
        {
            var data = new[] 
            {
                new BillSaleOrderDomain
            {
                SOrderNo=1,
                  CustID="abcdef01",
                    OrderDisc =0,
                    TaxAmt=5,
                    TotalAmt=10,
                    InvoiceID="XY"
            },
            new BillSaleOrderDomain
            {
                SOrderNo=2,
                   CustID="abcdef02",
                    OrderDisc =0,
                    TaxAmt=5,
                    TotalAmt=10,
                    InvoiceID="XY"
            }
            };
            var fakeObject = new Mock<IBillSaleOrderManagerService>();
            fakeObject.Setup(x => x.Confirm(It.IsAny<int>())).Returns(0);           
            int result = fakeObject.Object.Confirm(2);
            Assert.AreEqual(result, 0);
        }
       
    }
}
