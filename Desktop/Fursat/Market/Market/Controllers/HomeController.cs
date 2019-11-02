using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Market.Views.ViewModel.Default;
using Market.Areas.MarketAdmin.Controllers;
using PagedList;
using PagedList.Mvc;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        FursatEntities1 db = new FursatEntities1();

        public ActionResult Index(string searchBy, string search, int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;

            var defaultModel = new DefaultViewModel
            {
                SubCategory = db.SubCategories.ToList(),
                Slide = db.Slides.ToList(),
                productListPaged = db.Products.Where(x => x.Discount_price != null).OrderByDescending(m => m.Id).ToPagedList<Product>(_sayfaNo, 3),
            };
                return View(defaultModel);
            }

            public ActionResult About()
            {
                return View();
            }
        public ActionResult Online()
        {

            var defaultModel = new DefaultViewModel
            {
                Category = db.Categories.ToList(),
                productList = db.Products.ToList(),
                SubCategory = db.SubCategories.ToList(),

            };
            return View(defaultModel);
        }
        public ActionResult Contact()
        {
            var defaultModel = new DefaultViewModel
            {
                Contact = db.Contacts.Find(1)
            };
            return View(defaultModel);
        }
    }
}