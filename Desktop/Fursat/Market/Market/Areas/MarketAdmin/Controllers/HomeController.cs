using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market.Views.ViewModel.Default;

namespace Market.Areas.MarketAdmin.Controllers
{
   
    public class HomeController : Controller
    { 
         FursatEntities1 db = new FursatEntities1();
    public ActionResult Index()
    {

        ViewBag.UsersCount = db.Users.Count();
        ViewBag.OrdersCount = db.Orders.Count();
        var defaultModel = new DefaultViewModel
        {
            OrderList = db.Orders.ToList(),
        };
        return View(defaultModel);
    }
}
}