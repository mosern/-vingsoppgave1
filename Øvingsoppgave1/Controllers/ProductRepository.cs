﻿using Øvingsoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Øvingsoppgave1.Controllers
{
    public class ProductRepository : IRepository
    {
        public List<Product> getAll()
        {
            List<Product> products = new List<Product>{
                 new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                 new Product {Name="Vinkelsliper", Price=1520.00m, Category="Verktøy"},
                 new Product {Name="Melk", Price=14.50m, Category="Dagligvarer"},
                 new Product {Name="Kjøttkaker", Price=32.00m, Category="Dagligvarer"},
                 new Product {Name="Brød", Price=25.50m, Category="Dagligvarer"}
            };

            return products;
        }

        public void Save(Product p)
        {
        }
    }
}