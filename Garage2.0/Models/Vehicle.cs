using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

     //context.Vehicles.AddOrUpdate(
     //           p => p.VehicleID,
     //           new Vehicle { RegNr = "ABC123", Color =  "Blå", Vehicle_OwnerId = 1, Vehicle_TypeId = 1, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now},
     //           new Vehicle { RegNr = "ABC111", Color = "Vit", Vehicle_OwnerId = 2, Vehicle_TypeId = 1, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
     //           new Vehicle { RegNr = "ABC222", Color = "Röd", Vehicle_OwnerId = 3, Vehicle_TypeId = 3, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
     //           new Vehicle { RegNr = "ABC333", Color = "Grön", Vehicle_OwnerId = 4, Vehicle_TypeId = 4, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now },
     //           new Vehicle { RegNr = "ABC444", Color = "Röd", Vehicle_OwnerId = 5, Vehicle_TypeId = 2, ParkingIn = DateTime.Now, ParkingOut = DateTime.Now }
     //           );
     //       context.Owners.AddOrUpdate(
     //           p => p.Vehicle_OwnerId,
     //           new VehicleOwner { Vehicle_OwnerId = 1, OwnerName= "Arvid Arvidsson" },
     //           new VehicleOwner { Vehicle_OwnerId = 2, OwnerName = "Lisa Svensson" },
     //           new VehicleOwner { Vehicle_OwnerId = 3, OwnerName = "Johan Karlsson" },
     //           new VehicleOwner { Vehicle_OwnerId = 4, OwnerName = "Rut Hjort" },
     //           new VehicleOwner { Vehicle_OwnerId = 5, OwnerName = "Linda Svensson" }
     //           );
     //       context.Vehicle_Types.AddOrUpdate(
     //           p => p.Vehicle_TypeId,
     //           new Vehicle_Type { Vehicle_TypeId = 1, Name = "Bil" },
     //           new Vehicle_Type { Vehicle_TypeId = 2, Name = "Buss" },
     //           new Vehicle_Type { Vehicle_TypeId = 3, Name = "Motorcykel" },
     //           new Vehicle_Type { Vehicle_TypeId = 4, Name = "Moped" }
     //           );
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
    public class Vehicle_Type
    {
        [Key]
        public int Vehicle_TypeId { get; set; }
        [Display(Name = "Fordonstyp")]
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

    public class VehicleOwner
    {
        [Key]
        public int Vehicle_OwnerId { get; set; }
        [Display(Name = "Ägare")]
        public string OwnerName {get; set;}
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        public int? Vehicle_OwnerId { get; set; }
        //[ForeignKey("Vehicle_OwnerId")]
        public virtual VehicleOwner vehicleOwner { get; set; }

        public int? Vehicle_TypeId { get; set; }
        //[ForeignKey("Vehicle_TypeId")]
        [Display(Name = "Fordonstyp")]
        public virtual Vehicle_Type vehicle_Type { get; set; }

        //[Display (Name="Fordonstyp")]
        //public VehicleType Type { get; set; }
        //[Required Display(Name = "Ägare")]
        //public string Owner { get; set; }
        [Required Display(Name = "Reg Nr")]
        public string RegNr { get; set; }
        [Display(Name = "Färg")]
        public string Color { get; set; }
        [Display(Name = "Checkat IN")]
        public DateTime? ParkingIn { get; set; }
        [Display(Name = "Checkat UT")]
        public DateTime? ParkingOut { get; set; }
        [Display(Name = "P-plats Nr")]
        public int ParkingSpaceNr { get; set; }
        [Display(Name = "Reserverad")]
        public bool Reserved { get; set; }


    }
}