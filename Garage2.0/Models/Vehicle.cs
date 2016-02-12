using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


// Seed-funktion för Vehicle
            //context.Vehicles.AddOrUpdate(
            //    p => p.Owner,
            //    new Vehicle { Color=  "Blue", Owner = "Arvid Arvidsson", Type = VehicleType.Airplane, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now},
            //    new Vehicle { Color = "Green", Owner = "Anna Arvidsson", Type = VehicleType.Car, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
            //    new Vehicle { Color = "Red", Owner = "Annette Arvidsson", Type = VehicleType.Motorcycle, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
            //    new Vehicle { Color = "Cyan", Owner = "Anton Arvidsson", Type = VehicleType.Boat, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
            //    new Vehicle { Color = "Turquoise", Owner = "Annelie Arvidsson", Type = VehicleType.Bicycle, RegNr = "ABC123", ParkingIn = DateTime.Now, ParkingOut = DateTime.Now }
            //    );
namespace Garage2._0.Models
{
    public enum VehicleType
    {
        Car,
        Boat,
        Airplane,
        Motorcycle,
        Bicycle
    }
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }
        public VehicleType Type { get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }
        public string RegNr { get; set; }
        public DateTime ParkingIn { get; set; }
        public DateTime ParkingOut { get; set; }
        public int ParkingSpaceNr { get; set; }
        public bool Reserved { get; set; }
    }
}