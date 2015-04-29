using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HB8.CSMS.MVC.StructureMap
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x=>x.AddRegistry(new ApplicationRegistry()));
        }
    }
}