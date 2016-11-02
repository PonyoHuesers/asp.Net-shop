using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CraftsWebsite.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public Nullable<int> ProductsId { get; set; }
        public int Quantity { get; set; }

        public Products Product { get; set; }
    }
}