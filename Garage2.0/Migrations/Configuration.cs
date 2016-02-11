namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccessLayer.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2._0.DataAccessLayer.VehicleContext context)
        {
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
            context.Vehicles.AddOrUpdate(
                p => p.Owner,
                new Vehicle { Color=  "Blue", Owner = "Arvid Arvidsson", Type = VehicleType.Airplane, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now},
                new Vehicle { Color = "Green", Owner = "Anna Arvidsson", Type = VehicleType.Car, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                new Vehicle { Color = "Red", Owner = "Annette Arvidsson", Type = VehicleType.Motorcycle, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                new Vehicle { Color = "Cyan", Owner = "Anton Arvidsson", Type = VehicleType.Boat, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                new Vehicle { Color = "Turquoise", Owner = "Annelie Arvidsson", Type = VehicleType.Bicycle, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now }
                );
        }
    }
}
