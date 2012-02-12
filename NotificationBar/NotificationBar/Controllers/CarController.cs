using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NotificationBar.Code;
using NotificationBar.Models;

namespace NotificationBar.Controllers
{
    public class CarController : Controller
    {
        public ActionResult Index()
        {
            var cars = Database.List();
            var model = AutoMapper.Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(cars);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var car = Database.Read(id);
            var model = AutoMapper.Mapper.Map<Car, CarViewModel>(car);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CarCreateModel();
            return View(model);
        } 

        [HttpPost]
        public ActionResult Create(CarCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Database.Add(model.Make, model.Year);
                return RedirectToAction("Index").WithNotification(Status.Success, "Car has been created succesfully");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var car = Database.Read(id);
            var model = AutoMapper.Mapper.Map<Car, CarEditModel>(car);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CarEditModel model)
        {
            if (ModelState.IsValid)
            {
                Database.Update(model.Id, model.Make, model.Year);
                return RedirectToAction("Index").WithNotification(Status.Success, "Successfully Updated");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Database.Delete(id);
            return RedirectToAction("Index").WithNotification(Status.Warning, "The vehicle has been deleted.");    
        }

    }
}
