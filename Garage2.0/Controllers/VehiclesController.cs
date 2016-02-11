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

namespace Garage2._0.Controllers
{
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

        public IEnumerable<Vehicle> GetVehicles()
        {
            return context.Vehicles.ToList();
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
            return View(Garage.GetVehicles());
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
            return View();
        }

        // Searches for vehicles by owner
        // todo: searches on more variables
        public ActionResult Search(string q="")
        {
            var result = from v in Garage.GetVehicles()
                         where String.Compare(v.Owner, q, StringComparison.InvariantCultureIgnoreCase) == 0
                         select v;
            return View(result);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Color, Owner, RegNr")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "ID,Type,Color")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Garage.UpdateVehicle(vehicle);
                Garage.Save();
                return RedirectToAction("Index");
            }
            return View(vehicle);
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
    }
}
