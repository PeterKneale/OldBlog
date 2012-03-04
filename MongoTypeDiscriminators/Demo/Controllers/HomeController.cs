using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Demo.Code;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vehicles = new Services().ListVehicles();
            var model = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);
            return View(model);
        }
        public ActionResult Trucks()
        {
            var trucks = new Services().ListTrucks();
            var model = Mapper.Map<IEnumerable<Truck>, IEnumerable<TruckViewModel>>(trucks);
            return View(model);
        }
        public ActionResult Cars()
        {
            var cars = new Services().ListCars();
            var model = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(cars);
            return View(model);
        }
        public ActionResult CreateCar()
        {
            var randomSpeed = new Random().Next(40) + 60;
            var randomPassengers = new Random().Next(7) + 1;
            new Services().CreateCar(randomSpeed, randomPassengers);
            return RedirectToAction("Index");
        }
        public ActionResult CreateTruck()
        {
            var randomSpeed = new Random().Next(60) + 60;
            var randomLoad = new Random().Next(600) + 400;
            new Services().CreateTruck(randomSpeed, randomLoad);
            return RedirectToAction("Index");
        }
    }
}
