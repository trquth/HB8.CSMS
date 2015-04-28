using HB8.CSMS.BLL.Abstract;
using HB8.CSMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB8.CSMS.MVC4.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        private IStaffManagerService<User> staffMana;
        public DemoController(IStaffManagerService<User> staffMana)
        {
            this.staffMana = staffMana;
        }
        public ActionResult Index()
        {
            var model = staffMana.GetListPosition().First();
            return View(model);
        }

    }
}
