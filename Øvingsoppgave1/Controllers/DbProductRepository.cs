using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Øvingsoppgave1.Models;

namespace Øvingsoppgave1.Controllers
{
    public class DbProductRepository : IRepository
    {
        public List<Product> getAll()
        {
            DbModel db = new DbModel();
            return db.Products.ToList();
        }

        public void Save(Product p)
        {
            throw new NotImplementedException();
        }
    }
}