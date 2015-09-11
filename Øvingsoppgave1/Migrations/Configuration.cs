namespace Øvingsoppgave1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Øvingsoppgave1.Models.DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Øvingsoppgave1.Models.DbModel context)
        {
             context.Products.AddOrUpdate(

                 p => p.Name,

                 new Product { Name = "Hammer", Price = 121.50m, Category = "Verktøy" },
                 new Product { Name = "Vinkelsliper", Price = 1520.00m, Category = "Verktøy" },
                 new Product { Name = "Volvo XC90", Price = 990000m, Category = " Kjøretøy" },
                 new Product { Name = "Volvo XC60", Price = 620000m, Category = "Kjøretøy" },
                 new Product { Name = "Brød", Price = 25.50m, Category = "Dagligvarer" }
             );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
