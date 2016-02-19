using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage2._0.Models;
using Garage2._0.Controllers;

namespace Garage2._0.DataAccessLayer
{
    public interface IVehicleRepository : IDisposable
    {
        IEnumerable<Vehicle> GetVehicles(bool? today, FilterType filter = FilterType.All, VehicleType vehicleFilter = VehicleType.Car);
        Vehicle GetVehicleByID(int id);
        void InsertVehicle(Vehicle v);
        void RemoveVehicle(int id);
        void UpdateVehicle(Vehicle v);
        void Save();
        IEnumerable<Vehicle> SearchByRegNr(string regnr);
        IEnumerable<Vehicle> SearchByOwner(string owner, bool today);
        IEnumerable<Vehicle> FilterByType(VehicleType type);
        IEnumerable<Vehicle> GetTodaysParking();
        IEnumerable<Vehicle_Type> GetTypes();
        IEnumerable<VehicleOwner> GetOwners();
        IEnumerable<Vehicle> FilterList(string type, bool today = false, string q = "");

    }
}