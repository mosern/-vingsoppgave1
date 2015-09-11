using Øvingsoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Øvingsoppgave1.Controllers
{
    public class ProductController : Controller
    {
        public int pageSize = 2;
        private IRepository irepository = new ProductRepository();

        public ProductController()
        {
            irepository = new DbProductRepository();
        }

        public ProductController(IRepository irepository)
        {
            this.irepository = irepository;
        }

        public ActionResult Index()
        {
            List<Product> products = irepository.getAll();
            return View(products);
        }

        public ActionResult Create(Product p)
        {
            irepository.Save(p);
            return View(p);
        }

        public ActionResult List(int page = 1)
        {
            var products = irepository.getAll().Skip(pageSize*(page-1)).Take(pageSize);
            return View(products);
        }
    }
}