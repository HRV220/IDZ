using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IDZ.Controllers
{
    public class UserManagerController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AuctionList", "Auction");
        }
        public ActionResult Registration()
        {
            return View();
        }

    }
}