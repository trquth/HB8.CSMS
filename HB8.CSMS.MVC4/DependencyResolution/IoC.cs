// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.BLL.ConcreteFunctionsServer;
using HB8.CSMS.DAL.AbstractRepositories;
using HB8.CSMS.DAL.ConcreteFunctions;
using StructureMap;
using StructureMap.Graph;
namespace HB8.CSMS.MVC4.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();
                            x.For(typeof( IStaffManagerService<>)).Add(typeof(StaffManagerService<>));
                            x.For<IUserRepository>().Add<UserRepository>();
                            x.For<IStaffRepository>().Add<StaffRepository>();
                           
                        });
            return ObjectFactory.Container;
        }
    }
}