using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;

namespace HB8.CSMS.MVC.StructureMap
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;

            try
            {
                if ((requestContext ==null)||(controllerType==null))
                {
                    return null;
                }
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException)
            {

                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());

                throw ;
            }
        }

    }
}