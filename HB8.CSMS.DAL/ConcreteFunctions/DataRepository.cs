using HB8.CSMS.DAL.Abstract;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.ConcreteFunctions
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected CSMSContext context;
        public DataRepository()
        {
            context = new CSMSContext();
        }
        public DataRepository(CSMSContext context)
        {
            this.context = context;
        }
        protected DbSet<T> GetDbSet
        {
            get
            {
                return context.Set<T>();
            }
        }
        public T Create(T t)
        {
            var newEntry = GetDbSet.Add(t);
            return newEntry;

        }

        public int Update(T t)
        {
            var entry = context.Entry(t);
            GetDbSet.Attach(t);
            entry.State = EntityState.Modified;
            return 0;
        }

        public int Delete(T t)
        {
            GetDbSet.Remove(t);
            return 0;

        }
        public T GetItemById(string id)
        {
            return GetDbSet.Find(id);
        }

        public IQueryable<T> GetAllItem()
        {
            return GetDbSet.AsQueryable();
        }
    }
}
