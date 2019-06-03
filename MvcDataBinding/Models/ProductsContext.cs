using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcDataBinding.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(): base("ProductsConnection")
        {

        }
        public DbSet<Product> ProductTable { get; set; } 
    }
}