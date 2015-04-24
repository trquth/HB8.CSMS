using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.Abstract
{
    public interface IDataRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
        T GetItemById(string id);
        IQueryable<T> GetAllItem { get; }
    }
}
