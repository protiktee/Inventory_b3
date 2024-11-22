using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_b3.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        { 
            if (username == "admin" && password == "123")
            { 
                Session["username"] = username;
                ViewBag.Msg = "Login Success";
            }
            else
            {
                ViewBag.Msg = "Login Failed";
            }

            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}