using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.DataAccessLayer;
using Garage2._0.Models;
using System.Reflection;

namespace Garage2._0.Controllers
{
    public enum FilterType
    {
        All,
        ByType,
        Today
    }
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        private VehicleContext context = new VehicleContext();

        public VehicleRepository(VehicleContext _context)
        {
            this.context = _context;
        }
        public Vehicle GetVehicleByID(int id)
        {
            return context.Vehicles.Find(id);
        }

        public IEnumerable<Vehicle> GetVehicles(bool? today, FilterType filter = FilterType.All, VehicleType vehicleFilter = VehicleType.Car)
        {
            IEnumerable<Vehicle> results;
            switch (filter)
            {
                case FilterType.All:
                    {
                        results = context.Vehicles.ToList();
                        break;
                    }
                //case FilterType.ByType:
                //    {
                //        results = from v in context.Vehicles
                //                      where vehicleFilter == v.vehicleType
                //                      select v;
                //        break;
                //    }
                case FilterType.Today:
                    {
                        results = from v in context.Vehicles
                                     where v.ParkingIn == DateTime.Today
                                     select v;
                        break;
                    }
                default:
                    {
                        results = context.Vehicles.ToList();
                    }
                    break;
            }
            if(today == true)
            {
                results = from v in results
                          where v.ParkingIn.Value.Date == DateTime.Today
                          select v;
            }
            //var r = results.OrderBy(x => x.vehicleType).ThenByDescending(y => y.ParkingIn);
           return ( results);
            
        }

        public void InsertVehicle(Vehicle v)
        {
            context.Vehicles.Add(v);
        }

        public void RemoveVehicle(int id)
        {
            Vehicle v = context.Vehicles.Find(id);
            context.Vehicles.Remove(v);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public IEnumerable<Vehicle> SearchByRegNr(string regnr)
        {
            var result = from v in context.Vehicles
                         where String.Compare(v.RegNr, regnr, StringComparison.InvariantCultureIgnoreCase) == 0
                         select v;
            return (result);
        }

        public IEnumerable<Vehicle> SearchByOwner(string owner, bool today)
        {
            //var result = from v in context.Vehicles
            //             where String.Compare(v.Vehicle_OwnerId, owner, StringComparison.InvariantCultureIgnoreCase) == 0
            //             select v;

            //if (today == true)
            //{
            //    result = from v in result
            //              where v.ParkingIn.Value.Date == DateTime.Today
            //              select v;
            //}
            //return (result);
            return null;
        }

        public IEnumerable<Vehicle> FilterByType(VehicleType type)
        {
            //var result = from v in context.Vehicles
            //             where v.Vehicle_TypeId == type
            //             select v;
            //return (result);
            return null;
        }
        // Returns all the vehicles to have entered the garage today.
        public IEnumerable<Vehicle> GetTodaysParking()
        {
            var result = from v in context.Vehicles
                         where v.ParkingIn == DateTime.Today
                         select v;
            return (result);
        }

        public void UpdateVehicle(Vehicle v)
        {
            context.Entry(v).State = EntityState.Modified;
        }
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ////
        //// Owner

        public IEnumerable<VehicleOwner> GetOwners()
        {
            return context.Owners.ToList();
        }

        ////
        //// Vehicle_Types

        public IEnumerable<Vehicle_Type> GetTypes()
        {
            return context.Vehicle_Types.ToList();
        }


        ////

        public IEnumerable<Vehicle> FilterSearch(string regnr, string vehicleTypeFilter)
        {
            if (String.IsNullOrEmpty(vehicleTypeFilter)) // Om det är första gången vi laddar sidan
            {
                return GetVehicles(false).ToList(); // Returnera ALLA fordon
            }


            if (String.IsNullOrEmpty(regnr)) // Om det inte är skrivet i regnr-fältet, filtrera efter fordon
            {
                if(String.Compare(vehicleTypeFilter,"All", StringComparison.InvariantCultureIgnoreCase) == 0) // Om vår dropdownlist skickar "All" returnera alla fordon.
                {
                    return GetVehicles(false).ToList();
                }
                var results = from v in context.Vehicles // Annars gör vi en sökning på fordonstypen.
                              where (String.Compare(vehicleTypeFilter, v.Vehicle_Type.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
                              select v;
                return results;
            }
            else // Om det ÄR skrivet i regnr-fältet, sök på regnr
            {
                return SearchByRegNr(regnr);
            }
        }
    }
    public class VehiclesController : Controller
    {
        // Detta är den klass som pratar med vår database context.
        private IVehicleRepository Garage; 

        public VehiclesController()
        {
            this.Garage = new VehicleRepository(new VehicleContext());
        }

        public VehiclesController(IVehicleRepository garage)
        {
            this.Garage = garage;
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(Garage.GetVehicles(false));
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Garage.GetVehicleByID((int) id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            List<SelectListItem> dropdownlist = new List<SelectListItem>();
            foreach (var v in Garage.GetTypes())
            {
                dropdownlist.Add(new SelectListItem { Text = v.Name, Value = v.Vehicle_TypeId.ToString() });
            }


            ViewData["Vehicle_TypeId"] = dropdownlist; /*new SelectList(dropdownlist);*/
            return View();
        }
        // GET: Vehicles/Detailed_list
        public ActionResult Detailed_list(string q, string Fordonstyper)
        {
            return View(Garage.FilterSearch(q, Fordonstyper));
        }
        [HttpGet]
        public ActionResult Index(string q, string Fordonstyper)
        {

            return View(Garage.FilterSearch(q, Fordonstyper));
        }
        //[HttpGet]
        //public ActionResult Index(string type, bool today=false,  string q = "")/*(string q="", FilterType filter = FilterType.All, VehicleType type = VehicleType.Car)*/
        //{
        //    return View(Garage.FilterList(type,today,q));
        //}

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = ",Type,Color, Owner, RegNr")]
        public ActionResult Create( Vehicle vehicle)
        {


            if (ModelState.IsValid)
            {
                vehicle.ParkingIn = DateTime.Now;
                vehicle.ParkingOut = DateTime.Now.AddHours(2);
                Garage.InsertVehicle(vehicle);
                Garage.Save();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Garage.GetVehicleByID((int)id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Garage.UpdateVehicle(vehicle);
                Garage.Save();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        [HttpGet]
        public ActionResult Search(string q="", string val="")
        {
            if( String.IsNullOrEmpty(q) )
            {
                return View(Garage.GetVehicles(false));
            }

            if (val == "owner")
            {
                return View(Garage.SearchByOwner(q, false));
            }
            else if (val == "reg")
            {
                return View(Garage.SearchByRegNr(q));
            }
            else
                return View(Garage.GetVehicles(false));
        }
        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Garage.GetVehicleByID((int)id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garage.RemoveVehicle(id);
            Garage.Save();
            return RedirectToAction("Index");
        }

        public ActionResult _Filter()
        {
            return PartialView(Garage.GetTypes());
        }

        public ActionResult _FilterDetailed()
        {
            return PartialView(Garage.GetTypes());
        }
    }
}
