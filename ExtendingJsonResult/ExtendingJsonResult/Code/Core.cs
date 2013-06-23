using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendingJsonResult.Code
{
    public class Product
    {
        public int Id;
        public string Description;
    }
    public class Core
    {
        private static readonly List<Product> Products;

        static Core()
        {
            Products = new List<Product>
                        {
                            new Product {Id = 1, Description = "Alpha"},
                            new Product {Id = 2, Description = "Beta"},
                            new Product {Id = 3, Description = "Cappa"},
                            new Product {Id = 4, Description = "Delta"}
                        };
        }

        public static IEnumerable<Product> ListAll()
        {
            return Products;
        }

        public static IEnumerable<Product> RandomTwo()
        {
            return Products.Skip(new Random().Next(2)).Take(2);
        }
    }
}