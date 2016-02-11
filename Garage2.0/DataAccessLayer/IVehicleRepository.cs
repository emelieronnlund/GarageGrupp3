using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage2._0.Models;

namespace Garage2._0.DataAccessLayer
{
    public interface IVehicleRepository : IDisposable
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicleByID(int id);
        void InsertVehicle(Vehicle v);
        void RemoveVehicle(int id);
        void UpdateVehicle(Vehicle v);
        void Save();
    }
}