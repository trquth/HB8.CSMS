using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB8.CSMS.MVC.Controllers
{
    public class InventoryManagerController : Controller
    {
        //
        // GET: /InventoryManager/

        public ActionResult ListInventory()
        {
            return View();
        }

    }
}
