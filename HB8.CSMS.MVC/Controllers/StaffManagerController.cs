using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB8.CSMS.MVC.Controllers
{
    public class StaffManagerController : Controller
    {
        //
        // GET: /StaffManager/
        private readonly IStaffManagerService staffManager;
        public StaffManagerController(IStaffManagerService staffManager)
        {
            this.staffManager = staffManager;
        }
        public ActionResult CreateNewStaff()
        {
            return View();
        }

    }
}
