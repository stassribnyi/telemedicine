using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telemedicine.Web.Attributes;

namespace Telemedicine.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
    }
}