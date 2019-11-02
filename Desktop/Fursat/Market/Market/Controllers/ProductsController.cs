using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market.Models;
using System.Net;
using Market.Views.ViewModel.Default;

namespace Market.Controllers
{
    public class ProductsController : Controller
    {
        FursatEntities1 db = new FursatEntities1();
        // GET: Products
        public ActionResult Product(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");


            SubCategory subcatId = db.SubCategories.FirstOrDefault(sub => sub.İd == id);
            if (subcatId == null) return RedirectToAction("Index", "Home");

            Category catId = db.Categories.FirstOrDefault(sub => sub.Id == id);
            if (catId == null) return RedirectToAction("Index", "Home");

            var defaultModel = new DefaultViewModel
            {
                Category = db.Categories.ToList(),
                SubCategory = db.SubCategories.ToList(),
                productList = db.Products.Where(pr => pr.subCategoryId == subcatId.İd || pr.SubCategory.CategoryId == catId.Id).ToList(),

            };
            return View(defaultModel);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product SelectPro = db.Products.Find(id);
            if (SelectPro == null)
            {
                return HttpNotFound();
            }
            var defaultModel = new DefaultViewModel
            {
                Category = db.Categories.ToList(),
                SubCategory = db.SubCategories.ToList(),
                ProImage = db.Products.Where(pri => pri.Id == id).ToList(),
                ProductDetail = db.Products.FirstOrDefault(pr => pr.Id == id),
                productList = db.Products.Where(pr => pr.Id == id).ToList(),

                //OptionPro=db.ProductOptions.Where(a=>a.Id==id).ToList(),
            };
            return View(defaultModel);
        }

    }
}