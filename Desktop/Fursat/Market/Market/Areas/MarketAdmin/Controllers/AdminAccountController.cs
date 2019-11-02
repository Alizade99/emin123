using System;
using Market.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace Market.Areas.MarketAdmin.Controllers
{
    public class AdminAccountController : Controller
    {
        FursatEntities1 db = new FursatEntities1();
        // GET: MarketAdmin/AdminAccount
        public ActionResult Login(string Email, string Password)
        {
            if (Email != string.Empty && Password != String.Empty)
            {
                Admin adm = db.Admins.Find(1);
                if (adm.Name == Email && adm.Password==Password)
                {
                    Session["adminLogged"] = adm;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Email or password is not correct!";
                }
            }
            else
            {
                ViewBag.Error = "Please all the fill";
            }

            return View();
        }
    }
}