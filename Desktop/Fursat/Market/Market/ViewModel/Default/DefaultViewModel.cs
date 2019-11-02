using Market.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Views.ViewModel.Default
{
    public class DefaultViewModel
    {
        public AboutU AboutUs;
        public Admin Admin;
        public List<User> User;
        public List<Slide> Slide;
        public List<Order> Order;
        public List<SubCategory> SubCategory;
        public List<Product> ProImage;
        public Contact  Contact;
        public Product ProductDetail;
        public string CategoryName;
        public List<Category> Category;
        public IEnumerable<Product> productList;
        public IPagedList<Product> productListPaged;

        public List<Order> OrderList;
    }
}