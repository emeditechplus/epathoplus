using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using FactoryModel;
using FactoryDatacontext;
using System.Web.Mvc;
using FactoryModule1.Helpers;

namespace FactoryModule1.Controllers
{
   
    public class usercontroller : Controller
    {
        public ICacheManager _ICacheManager;

        Usercontext usercontext = new Usercontext();
        // GET: User
        public usercontroller()
        {
            _ICacheManager = new CacheManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)

        {
            
         
           
            return View(loginViewModel);
        }
        public List<Finyear> Bindfinyr()
        {
            List<Finyear> finyr = new List<Finyear>();
         
            return finyr;
        }

        [HttpPost]
        public JsonResult Getfinyr(string finyr)
        {
            Session["FINYEAR"] = finyr.Trim();
            _ICacheManager.Add("FINYEAR", finyr.Trim());
            return Json(finyr, JsonRequestBehavior.AllowGet);

        }

        }
}