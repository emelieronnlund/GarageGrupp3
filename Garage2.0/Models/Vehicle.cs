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
        string Owner { get; set; }
        string RegNr { get; set; }
        DateTime ParkingIn { get; set; }
        DateTime ParkingOut { get; set; }
        int ParkingSpaceNr { get; set; }
        bool Reserved { get; set; }
    }
}