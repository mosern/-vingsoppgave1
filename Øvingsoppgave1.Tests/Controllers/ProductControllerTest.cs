using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Øvingsoppgave1.Models;
using System.Collections.Generic;
using Moq;
using Øvingsoppgave1.Controllers;
using System.Web.Mvc;
using System.Collections;

namespace Øvingsoppgave1.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            List<Product> products = new List<Product>{
                 new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                 new Product {Name="Vinkelsliper", Price=1520.00m, Category="Verktøy"},
                 new Product {Name="Melk", Price=14.50m, Category="Dagligvarer"},
                 new Product {Name="Kjøttkaker", Price=32.00m, Category="Dagligvarer"},
                 new Product {Name="Brød", Price=25.50m, Category="Dagligvarer"}
            };

            Mock<IRepository> irepository = new Mock<IRepository>();

            irepository.Setup(x => x.getAll()).Returns(products);
            var controller = new ProductController(irepository.Object);

            var result = (ViewResult)controller.Index();
            var product = result.ViewData.Model as List<Product>;

            Assert.AreEqual(5, product.Count);
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
        }

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            List<Product> products = new List<Product>{
                 new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                 new Product {Name="Vinkelsliper", Price=1520.00m, Category="Verktøy"},
                 new Product {Name="Melk", Price=14.50m, Category="Dagligvarer"},
                 new Product {Name="Kjøttkaker", Price=32.00m, Category="Dagligvarer"},
                 new Product {Name="Brød", Price=25.50m, Category="Dagligvarer"}
            };

            Mock<IRepository> irepository = new Mock<IRepository>();

            irepository.Setup(x => x.getAll()).Returns(products);
            var controller = new ProductController(irepository.Object);

            var result = (ViewResult)controller.Create(new Product { Name = "Hammer", Price = 121.50m, Category = "Verktøy" });
            var product = result.ViewData.Model as List<Product>;
            irepository.Verify(m => m.Save(It.IsAny<Product>() ), Times.AtLeastOnce());
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            List<Product> products = new List<Product>{
                 new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                 new Product {Name="Vinkelsliper", Price=1520.00m, Category="Verktøy"},
                 new Product {Name="Melk", Price=14.50m, Category="Dagligvarer"},
                 new Product {Name="Kjøttkaker", Price=32.00m, Category="Dagligvarer"},
                 new Product {Name="Brød", Price=25.50m, Category="Dagligvarer"}
            };

            Mock<IRepository> irepository = new Mock<IRepository>();

            irepository.Setup(m => m.getAll()).Returns(products);

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            IEnumerable<Product> result =
            (IEnumerable<Product>)controller.List(2).Model;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
