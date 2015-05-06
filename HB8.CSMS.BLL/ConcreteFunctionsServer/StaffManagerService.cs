using HB8.CSMS.BLL.Abstract;
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

        public Staff CreateStaff(Staff staff)
        {
            context.Staffs.Create(staff);
            context.SaveChange();
            return staff;
        }


        public IEnumerable<Staff> GetListStaff()
        {
            return context.Staffs.GetAllItem();

        }


        public Staff GetStaffById(string id)
        {
            return context.Staffs.GetItemById(id);
        }
    }
}
