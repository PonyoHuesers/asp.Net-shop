using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CraftsWebsite.Models;

namespace CraftsWebsite.ViewModel
{
    public class ShoppingCartViewModel
    {
        public int pageNumber { get; set; }
 
        //Id of the user's cart
        public int userId { get; set; }
        public string userName { get; set; }
        public decimal userBalance { get; set; }
        public bool cartEmpty { get ; set; }

        //used in Shopping Cart View
        public int location { get; set; }
        public int locationId { get; set; }
        public int locationName { get; set; }

        public Customers customer { get; set; }
    }
}