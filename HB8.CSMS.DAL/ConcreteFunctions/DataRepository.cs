using HB8.CSMS.DAL.Abstract;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.ConcreteFunctions
{
    public class DataRepository<T> :DataContext,IDataRepository<T>
    {
        public DataRepository(CSMSContext context):base(context){}
        public void Insert(T item)
        {
           
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public T GetItemById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllItem
        {
            get { throw new NotImplementedException(); }
        }
    }
}
