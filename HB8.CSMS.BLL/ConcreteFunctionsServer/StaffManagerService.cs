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
    public class StaffManagerService<T>: IStaffManagerService<T> where T:class 
    {
        private IDataRepository<T> userRepo;
        public StaffManagerService(IDataRepository<T> userRepo)
        {
            this.userRepo = userRepo;
        }
        /// <summary>
        /// Lấy về danh sách các chức vụ 
        /// </summary>
        /// <returns></returns>
        IQueryable<T> IStaffManagerService<T>.GetListPosition()
        {
            return userRepo.GetAllItem();
        }
    }
}
