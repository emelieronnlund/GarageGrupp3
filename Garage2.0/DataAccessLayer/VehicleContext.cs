using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Garage2._0.Models;

namespace Garage2._0.DataAccessLayer
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("DefaultConnection") { }

        public System.Data.Entity.DbSet<Vehicle> Vehicles { get; set; }
        public System.Data.Entity.DbSet<Vehicle_Type> Vehicle_Types { get; set; }
        public System.Data.Entity.DbSet<VehicleOwner> Owners { get; set; }
    }
}