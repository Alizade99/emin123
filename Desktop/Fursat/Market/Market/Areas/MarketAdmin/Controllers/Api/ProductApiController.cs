//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using Market.Models;

//namespace Market.Areas.MarketAdmin.Controllers.Api
//{
//    FursatEntities db = new FursatEntities();
//    public class ProductApiController: 
//    {
//        public IEnumerable<Product> GetProducts()
//        {
//            return db.Product.ToList();
//        }
//        //Get/api/product/1
//        public Product GetProduct(int id)
//        {
//            var pro = db.Product.SingleOrDefault(p => p.Id == id);
//            if (pro == null)
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            return pro;
//        }
//        //Post/api/Products
//        [HttpPost]
//        public Product CreateProduct(Product product)
//        {
//            if (!ModelState.IsValid)
//                throw new HttpResponseException(HttpStatusCode.BadRequest);
//            db.Product.Add(product);
//            db.SaveChanges();
//            return product;
//        }
//        [HttpPut]
//        public void UpdateProduct(int id, Product product)
//        {
//            if (!ModelState.IsValid)
//                throw new HttpResponseException(HttpStatusCode.BadRequest);
//            var ProductDb = db.Product.SingleOrDefault(c => c.Id == id);
//            if (ProductDb == null)
//                throw new HttpResponseException(HttpStatusCode.NotFound);

//            ProductDb.Name = product.Name;
//            ProductDb.Image = product.Image;
//            ProductDb.AddDate = product.AddDate;
//            ProductDb.Count = product.Count;
//            ProductDb.Discount = product.Discount;
//            ProductDb.Price = product.Price;
//            ProductDb.SubCategory.Name = product.SubCategory.Name;


//            db.SaveChanges();
//        }
//        //Delete/api/products/1
//        [HttpDelete]
//        public void DeletePro(int id)
//        {
//            var ProductDb = db.Product.SingleOrDefault(c => c.Id == id);
//            if (ProductDb == null)
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            db.Product.Remove(ProductDb);
//            db.SaveChanges();

//        }
//    }
//}
