using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CraftsWebsite.Models;

namespace CraftsWebsite.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ShopEntities shopDB;

        public CustomersController()
        {
            shopDB = new ShopEntities();
        }

        /*GET /api/customers 
        public IEnumerable<Customer> GetCustomers()
        {
            return shopDB.Customers.Include("Products").ToList();
        }*/

        //GET /api/customers/1
        public IQueryable GetCustomer(int id)
        {
            var customer = shopDB.Customers.SingleOrDefault(c => c.CustomerId == id);
            var query = shopDB.Customers.Include("Products").Where(c => c.Email == customer.Email && c.Quantity > 0);
            //var query = shopDB.Customers.Include("Products").Where(c => c.Email == customer.Email && c.Quantity > 0);
            var customerInDB = query.Select(c => new { c.Email, c.Quantity, c.Balance, c.Products.Name, c.Products.Price, c.Products.ProductsId});
           
            return customerInDB;
        }

        //POST /api/customers/1
        [HttpPost]
        public void AddProductToCustomer(int id, int productId)
        {
            var customerPlaceHolder = shopDB.Customers.SingleOrDefault(c=>c.CustomerId == id);
            var customerBalance = shopDB.Customers.SingleOrDefault(c => c.Email == customerPlaceHolder.Email && c.ProductsId == null);

            var customerInDB = shopDB.Customers.SingleOrDefault(c => c.Email == customerPlaceHolder.Email && c.ProductsId == productId);
            var productInDB = shopDB.Products.SingleOrDefault(c => c.ProductsId == productId);

            if (customerInDB != null)
            {
                customerInDB.Quantity = customerInDB.Quantity + 1;
                customerInDB.Balance = customerInDB.Balance + productInDB.Price;
                //_context.CustomerDB.Add(customerInDB);
            }                
            else
            {
                var customerName = shopDB.Customers.FirstOrDefault(c => c.CustomerId == id);

                var newCustomer = new Customers
                {
                    Email = customerName.Email,
                    Balance = productInDB.Price,
                    ProductsId = productId,
                    Quantity = 1
                };

                shopDB.Customers.Add(newCustomer);
            }


            customerBalance.Balance = customerPlaceHolder.Balance + productInDB.Price;
            shopDB.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public decimal DeleteProduct(int id, int productId)
        {
            var customerPlaceHolder = shopDB.Customers.SingleOrDefault(c => c.CustomerId == id);
            var customerInDB = shopDB.Customers.SingleOrDefault(c => c.Email == customerPlaceHolder.Email && c.ProductsId == productId);
            
            var customerBalance = shopDB.Customers.SingleOrDefault(c => c.Email == customerPlaceHolder.Email && c.ProductsId == null);

            customerBalance.Balance = (decimal)customerBalance.Balance - customerInDB.Balance;
            shopDB.Customers.Remove(customerInDB);
            shopDB.SaveChanges();

            return customerBalance.Balance;          
        }
    }
}
