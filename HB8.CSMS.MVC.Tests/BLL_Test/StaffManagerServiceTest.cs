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
    class StaffManagerServiceTest
    {
        [Test]
        public void GetListPositionTest()
        {
        }
        [Test]
        public void GetListPositionTestWithMoq()
        {
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.GetListPosition()).Returns(() => new List<User> {
                new User(){UserID="AD",UserName="Quản lí",Role="Quản lí"},new User(){UserID="KK",UserName="Kiểm kho",Role="Nhân viên"}});
            var result = fakeObject.Object.GetListPosition();
            Object.Equals(new List<User> { new User() { UserID = "AD", UserName = "Quản lí", Role = "Quản lí" }, new User() { UserID = "KK", UserName = "Kiểm kho", Role = "Nhân viên" } }, result);
        }
        [Test]
        public void CreateStaffTest()
        {
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.CreateStaff(It.IsAny<StaffDomain>())).Returns(0);
            var staff = new StaffDomain
            {
                ID = "ABC10",
                UserId = "KK",
                StaffName = "TRQUTH",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = "null",
                Password = "123",
            };
            int i = fakeObject.Object.CreateStaff(staff);
            Assert.AreEqual(0, i);
        }
        [Test]
        public void UpdateStaffTest()
        {
            var data = new[] 
            {
                new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            },
            new Staff
            {
                StaffID = "ABC11",
                UserId = "KK",
                StaffName = "Trquthuat",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            }
            };
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.UpdateStaff(It.IsAny<StaffDomain>())).Returns(0);
            var editStaff = new StaffDomain
            {
                ID = "ABC10",
                UserId = "AD",
                StaffName = "Trquth",
                Image = null,
                Address = "TP HCM",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            };
            int result = fakeObject.Object.UpdateStaff(editStaff);
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void GetStaffByIdTest()
        {
            string id = "ABC10";
            var staff = new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            };
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.GetStaffById(It.IsAny<string>())).Returns(() => new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            });
            var result = fakeObject.Object.GetStaffById(id);
            Object.Equals(result, new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            });
        }
        [Test]
        public void DeleteStaffTest()
        {
            var data = new[] 
            {
                new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            },
            new Staff
            {
                StaffID = "ABC11",
                UserId = "KK",
                StaffName = "Trquthuat",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            }
            };
            string id = "ABC11";
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.DeleteStaff(It.IsAny<string>())).Returns(0);
            int result = fakeObject.Object.DeleteStaff(id);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void ReturnIndexStaff()
        {
            var data = new[] 
            {
                new Staff
            {
                StaffID = "ABC10",
                UserId = "KK",
                StaffName = "Trquth",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            },
            new Staff
            {
                StaffID = "ABC11",
                UserId = "KK",
                StaffName = "Trquthuat",
                Image = null,
                Address = "Ben tre",
                NumberPhone = "01668054746",
                Email = null,
                Password = "123"
            }
            };
            string id = "ABC11";
            var fakeObject = new Mock<IStaffManagerService>();
            fakeObject.Setup(x => x.ReturnIndexStaff(It.IsAny<string>())).Returns(2);
            int result = fakeObject.Object.ReturnIndexStaff(id);
            Assert.AreEqual(2, result);
        }
    }
}
