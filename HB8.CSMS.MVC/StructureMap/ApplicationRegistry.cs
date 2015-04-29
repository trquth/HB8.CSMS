using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.ConcreteFunctionsServer;
using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.ConcreteFunctions;
using HB8.CSMS.DAL.Models;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace HB8.CSMS.MVC.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            For(typeof(IStaffManagerService<>)).Use(typeof(StaffManagerService<>));
            For(typeof(IDataRepository<>)).Use(typeof(DataRepository<>));
            Scan(x =>
            {
                
            });
        }
    }
}