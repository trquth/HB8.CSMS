using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.ConcreteFunctionsServer
{
    public class StaffManagerService<T> : IStaffManagerService<User>,IStaffManagerService<Staff>
    {
        private IUserRepository userRepo;
        public StaffManagerService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        /// <summary>
        /// Lấy về danh sách các chức vụ 
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetListPosition()
        {
            return userRepo.GetAllItem();
        }

        IQueryable<Staff> IStaffManagerService<Staff>.GetListPosition()
        {
            throw new NotImplementedException();
        }
    }
}
