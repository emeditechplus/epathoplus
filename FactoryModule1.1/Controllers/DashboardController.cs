using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryModule1._1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Billing()
        {
            return View();
        }
        public ActionResult ReportingDashboard()
        {
            return View();
        }
        public ActionResult Reporting()
        {
            return View();
        }
    }
}