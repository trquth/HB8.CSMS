using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.DAL.ConcreteFunctions
{
   public class CustomerRepository: DataRepository<Customer>, ICustomerRepository
    {
       public CustomerRepository(CSMSContext context) : base(context) { }
    }
}
