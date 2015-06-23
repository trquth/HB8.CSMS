using HB8.CSMS.BLL.Abstract;
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
    class CustomerManagerServiceTest
    {
        [Test]
        public void CreateCustomerTest()
        {
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.CreateCustomer(It.IsAny<CustomerDomain>())).Returns(0);
            var customer = new CustomerDomain
            {
                CustID = "abcdef01",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax = null,
                Email = "abc@gmail.com",
                StatusID = "AV",
            };
            int i = fakeObject.Object.CreateCustomer(customer);
            Assert.AreEqual(0, i);
        }
        [Test]
        public void GetListCustomersTest()
        {
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.GetListCustomers()).Returns(() => new List<Customer> {
                new Customer(){CustID="abcdef01",CustName="TRQUTH",Address="Bến Tre", Phone="01668054746",Email="abc@gmail.com"},new Customer(){CustID="abcdef02",CustName="TRQUTH",Address="Bến Tre", Phone="01668054746",Email="abc@gmail.com"}});
            var result = fakeObject.Object.GetListCustomers();
            Object.Equals(new List<Customer> {
                new Customer(){CustID="abcdef01",CustName="TRQUTH",Address="Bến Tre", Phone="01668054746",Email="abc@gmail.com"},new Customer(){CustID="abcdef02",CustName="TRQUTH",Address="Bến Tre", Phone="01668054746",Email="abc@gmail.com"}}, result);
        }
        [Test]
        public void UpdateCustomerTest()
        {
            var data = new[] 
            {
                new Customer
            {
                 CustID = "abcdef01",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            },
            new Customer
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            }
            };
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.UpdateCustomer(It.IsAny<CustomerDomain>())).Returns(0);
            var editCustomer = new CustomerDomain
            {
                CustID = "abcdef02",
                CustName = "TRQUTHUAT",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax = null,
                Email = "abc@gmail.com",
            };
            int result = fakeObject.Object.UpdateCustomer(editCustomer);
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void DeleteCustomerTest()
        {
            var data = new[] 
            {
                new Customer
            {
                 CustID = "abcdef01",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            },
            new Customer
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            }
            };
            string id = "abcdef01";
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.DeleteCustomer(It.IsAny<string>())).Returns(0);
            int result = fakeObject.Object.DeleteCustomer(id);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void GetListStatusTest()
        {
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.GetListStatus()).Returns(() => new List<Status> {
                new Status(){StatusId="AV",StatusName="Đang hoạt động"},new Status(){StatusId="DE",StatusName="Đã bị xóa"}});
            var result = fakeObject.Object.GetListStatus();
            Object.Equals(new List<Status> {
                new Status(){StatusId="AV",StatusName="Đang hoạt động"},new Status(){StatusId="DE",StatusName="Đã bị xóa"}}, result);
        }
        [Test]
        public void GetCustomerByIdTest()
        {
            string id = "abcdef02";
            var customer = new Customer
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax = null,
                Email = "abc@gmail.com", 
            };
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.GetCustomerById(It.IsAny<string>())).Returns(() => new CustomerDomain
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax = null,
                Email = "abc@gmail.com",
            });
            var result = fakeObject.Object.GetCustomerById(id);
            Object.Equals(result, new CustomerDomain
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax = null,
                Email = "abc@gmail.com",
            });
        }
        [Test]
        public void ReturnIndexCustomerTest()
        {
            var data = new[] 
            {
                new Customer
            {
                 CustID = "abcdef01",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            },
            new Customer
            {
                CustID = "abcdef02",
                CustName = "TRQUTH",
                Address = "Ben tre",
                Phone = "01668054746",
                Fax= null,
                Email = "abc@gmail.com",  
            }
            };
            string id = "abcdef02";
            var fakeObject = new Mock<ICustomerManagerService>();
            fakeObject.Setup(x => x.ReturnIndexCustomer(It.IsAny<string>())).Returns(2);
            int result = fakeObject.Object.ReturnIndexCustomer(id);
            Assert.AreEqual(2, result);
        }
    }
}
