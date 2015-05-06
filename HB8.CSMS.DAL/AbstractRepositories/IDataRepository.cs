using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.AbstractRepositories
{
    public interface IDataRepository<T> where T : class
    {
        /// <summary>
        /// Insert mot doi tuong vao database
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Create(T t);
        /// <summary>
        /// Update mot doi tuong vao database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// Detele mot doi tuong khoi database
        /// </summary>
        /// <param name="item"></param>
        int Delete(T t);
        /// <summary>
        /// Tim mot doi tuong dua vao ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItemById(string id);
        /// <summary>
        /// Lay ra danh sach tu database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllItem();
        /// <summary>
        /// Tim mot doi tuong bang khóa
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        T Find(params object[] keys);
    }
}
