using System;
using System.Linq;
using Minimarket.Models;

namespace Minimarket.Services
{
    public class DbInitializer
    {
        public static void Initialize(MinimarketDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any()) return; // DB has been seeded

            var products = new Product[]
            {
                new Product { Name = "Product1", Price = 10.0M },
                new Product { Name = "Product2", Price = 20.0M },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}