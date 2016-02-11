using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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