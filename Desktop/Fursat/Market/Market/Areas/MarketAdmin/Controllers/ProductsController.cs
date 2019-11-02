using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Market.Models;
using System.Web.UI;

namespace Market.Areas.MarketAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private FursatEntities1 db = new FursatEntities1();

        // GET: MarketAdmin/Products
        public ActionResult Index(int page=1)
        {
            //var products = db.Products.Include(p => p.SubCategory);
            //var productList = db.Products.Include(p => p.SubCategory).OrderByDescending(pr => pr.Id).ToPagedList(Page, 4);

            return View(/*productList*/);
        
        }

        // GET: MarketAdmin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: MarketAdmin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = db.Categories.ToList();
            ViewBag.subCategoryId = new SelectList(db.SubCategories, "İd", "Name");
            return View();
        }

        // POST: MarketAdmin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Price,Time,Name,Discount_price,İconimg,Amount,Date,subCategoryId")] Product product, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {

            if (Photo!= null)
                {
                    if (
                        Photo.ContentType.ToLower() == "image/jpg" ||
                        Photo.ContentType.ToLower() == "image/png" ||
                        Photo.ContentType.ToLower() == "image/gif" ||
                        Photo.ContentType.ToLower() == "image/jpeg")
                    {
                        WebImage image = new WebImage(Photo.InputStream);
                        FileInfo photoInfo = new FileInfo(Photo.FileName);
                        string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                        image.Save("~/Uploads/ProductImage/" + newPhoto);
                        product.Image = "/Uploads/ProductImage/" + newPhoto;
                    }
                }
                product.Time = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = db.Categories.ToList();
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "İd", "Name", product.subCategoryId);
            return View(product);
        }

        // GET: MarketAdmin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "İd", "Name", product.subCategoryId);
            ViewBag.CategoryId = db.Categories.ToList();
            return View(product);
        }

        // POST: MarketAdmin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Price,Time,Name,Discount_price,İconimg,Amount,Date,subCategoryId")] Product product, int? id, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var productContents = db.Products.SingleOrDefault(m => m.Id == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(productContents.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(productContents.Image));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/Products/" + newPhoto);
                    productContents.Image = "/Uploads/Products/" + newPhoto;
                }

                productContents.Name = product.Name;
                productContents.Price = product.Price;
                productContents.Date = DateTime.Now;
                productContents.Amount = product.Amount;
                productContents.Discount_price = product.Discount_price;
                productContents.subCategoryId = product.subCategoryId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "İd", "Name", product.subCategoryId);
            ViewBag.CategoryId = db.Categories.ToList();

            return View(product);
        }

        // GET: MarketAdmin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/AddProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}