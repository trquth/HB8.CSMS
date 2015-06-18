using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.DomainModels;
using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.DBContext;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.ConcreteFunctionsServer
{
    public class StaffManagerService : IStaffManagerService
    {
        private IDALContext context;
        public StaffManagerService(IDALContext context)
        {
            this.context = context;
        }
        public List<User> GetListPosition()
        {
            return context.Users.GetAllItem().ToList();
        }

        public int CreateStaff(StaffDomain staff)
        {
            var model = new Staff();
            model.StaffID = staff.ID.ToUpper();
            model.UserId = staff.UserId;
            model.StaffName = staff.StaffName;
            model.NumberPhone = staff.NumberPhone;
            model.Image = staff.Image;
            model.Address = staff.Address;
            model.Email = staff.Email;
            model.Password = staff.Password;
            context.Staffs.Create(model);
            context.Save();
            return 0;
        }


        public IEnumerable<Staff> GetListStaff()
        {
            return context.Staffs.GetAllItem();

        }


        public Staff GetStaffById(string id)
        {
            return context.Staffs.GetItemById(id);
        }


        public int UpdateStaff(StaffDomain staff)
        {
            var model = context.Staffs.GetItemById(staff.ID);
            if (staff.Image != null)//kiem tra mot tam hinh neu ma khong co thay doi
            {
                model.Image = staff.Image;
            }        
            model.UserId = staff.UserId;
            model.StaffName = staff.StaffName;
            model.NumberPhone = staff.NumberPhone;
            model.Address = staff.Address;
            model.Email = staff.Email;
            model.Password = staff.Password;
            context.Staffs.Update(model);
            context.Save();
            return 0;
        }
        public int DeleteStaff(string id)
        {
            var model = context.Staffs.GetItemById(id);
            context.Staffs.Delete(model);
            context.Save();
            return 0;
        }
        public int ReturnIndexStaff(string id)
        {
            var model = context.Staffs.GetAllItem();
            int count = 1;
            foreach (var item in model)
            {
                if (item.StaffID.Equals(id))
                    break;
                count++;

            }
            return count;
        }
    }
}
