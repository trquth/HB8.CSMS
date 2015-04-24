using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.ConcreteFunctions
{
    public class DataContext
    {
        public DataContext() { }
        private CSMSContext context;
        public DataContext(CSMSContext context)
        {
            this.context = context;
        }
        private CSMSContext GetDbContext 
        {
            get
            {
                return context;
            }
        }
    }
}
