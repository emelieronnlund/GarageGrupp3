namespace Garage2._0.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccessLayer.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
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
                       p => p.VehicleID,
                       new Vehicle { RegNr = "ABC123", Color = "Blå", Vehicle_OwnerId = 1, Vehicle_TypeId = 1, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                       new Vehicle { RegNr = "ABC111", Color = "Vit", Vehicle_OwnerId = 2, Vehicle_TypeId = 1, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                       new Vehicle { RegNr = "ABC222", Color = "Röd", Vehicle_OwnerId = 3, Vehicle_TypeId = 3, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                       new Vehicle { RegNr = "ABC333", Color = "Grön", Vehicle_OwnerId = 4, Vehicle_TypeId = 4, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
                       new Vehicle { RegNr = "ABC444", Color = "Röd", Vehicle_OwnerId = 5, Vehicle_TypeId = 2, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now }
                       );
            context.Owners.AddOrUpdate(
                        p => p.Vehicle_OwnerId,
                        new VehicleOwner { Vehicle_OwnerId = 1, OwnerName = "Arvid Arvidsson" },
                        new VehicleOwner { Vehicle_OwnerId = 2, OwnerName = "Lisa Svensson" },
                        new VehicleOwner { Vehicle_OwnerId = 3, OwnerName = "Johan Karlsson" },
                        new VehicleOwner { Vehicle_OwnerId = 4, OwnerName = "Rut Hjort" },
                        new VehicleOwner { Vehicle_OwnerId = 5, OwnerName = "Linda Svensson" }
                        );
            context.Vehicle_Types.AddOrUpdate(
                        p => p.Vehicle_TypeId,
                        new Vehicle_Type { Vehicle_TypeId = 1, Name = "Bil" },
                        new Vehicle_Type { Vehicle_TypeId = 2, Name = "Buss" },
                        new Vehicle_Type { Vehicle_TypeId = 3, Name = "Motorcykel" },
                        new Vehicle_Type { Vehicle_TypeId = 4, Name = "Moped" }
                        );
        }
    }
}
