using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ODataService.Models
{
    public class ProductsRepository
    {
        public IList<Product> Products
        {
            get;
            private set;
        }

        public ProductsRepository(HttpSessionState session, string key)
        {
            Products = (IList<Product>)session[key];

            if (Products == null)
            {
                Products = new List<Product>()
                {
                    new Product { ID = 0, Name = "Bread", Description = "Whole grain bread", ReleaseDate = new DateTime(1992, 1, 1), DiscontinuedDate = null, Rating = 4, Price = 2.5m },
                    new Product { ID = 1, Name = "Milk", Description = "Low fat milk", ReleaseDate = new DateTime(1995, 10, 1), DiscontinuedDate = null, Rating = 3, Price = 3.5m },
                    new Product { ID = 2, Name = "Vint soda", Description = "Americana Variety - Mix of 6 flavors", ReleaseDate = new DateTime(2000, 10, 1), DiscontinuedDate = null, Rating = 3, Price = 20.9m },
                    new Product { ID = 3, Name = "Havina Cola", Description = "The Original Key Lime Cola", ReleaseDate = new DateTime(2005, 10, 1), DiscontinuedDate = new DateTime(2006, 10, 1), Rating = 3, Price = 19.9m },
                    new Product { ID = 4, Name = "Fruit Punch", Description = "Mango flavor, 8.3 Ounce Cans (Pack of 24)", ReleaseDate = new DateTime(2003, 1, 5), DiscontinuedDate = null, Rating = 3, Price = 22.99m },
                    new Product { ID = 5, Name = "Cranberry Juice", Description = "16-Ounce Plastic Bottles (Pack of 12)", ReleaseDate = new DateTime(2006, 8, 4), DiscontinuedDate = null, Rating = 3, Price = 22.8m },
                    new Product { ID = 6, Name = "Pink Lemonade", Description = "36 Ounce Cans (Pack of 3)", ReleaseDate = new DateTime(2006, 11, 5), DiscontinuedDate = null, Rating = 3, Price = 18.8m },
                    new Product { ID = 7, Name = "DVD Player", Description = "1080P Upconversion DVD Player", ReleaseDate = new DateTime(2006, 11, 15), DiscontinuedDate = null, Rating = 3, Price = 35.88m },
                    new Product { ID = 8, Name = "LCD HDTV", Description = "42 inch 1080p LCD with Built-in Blu-ray Disc Player", ReleaseDate = new DateTime(2008, 5, 8), DiscontinuedDate = null, Rating = 3, Price = 1088.8m }
                };

                session[key] = Products;
            }
        }
    }
}