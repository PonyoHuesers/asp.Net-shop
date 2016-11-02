using CraftsWebsite.Models;
using CraftsWebsite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CraftsWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ShopEntities shopDB;
        
        public HomeController()
        {
            shopDB = new ShopEntities();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ViewShop(int id)
        {
            var user = ControllerContext.HttpContext.User.Identity.Name;
            var userInDB = shopDB.Customers.FirstOrDefault(c => c.Email == user);

            var view = new ShoppingCartViewModel
            {
                userId = userInDB.CustomerId,
                pageNumber = id 
            };

            return View(view);
        }

        public ActionResult Cart()
        {
            var cartEmpty = false;

            var user = ControllerContext.HttpContext.User.Identity.Name;
            var userInDB = shopDB.Customers.Where(c => c.Email == user).OrderByDescending(c=>c.Balance).First();

            if (userInDB.Balance == 0)
                cartEmpty = true;

            var customerInDB = shopDB.Customers.SingleOrDefault(c => c.Email == user && c.ProductsId == null);

            var view = new ShoppingCartViewModel()
            {
                userId = userInDB.CustomerId,
                userName = user,
                cartEmpty = cartEmpty,
                customer = customerInDB
            };

            return View(view);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }
    }
}