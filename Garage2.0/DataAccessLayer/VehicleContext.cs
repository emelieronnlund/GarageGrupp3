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
        DbSet<Vehicle> Garage { get; set; }

        public System.Data.Entity.DbSet<Garage2._0.Models.Vehicle> Vehicles { get; set; }
    }
}