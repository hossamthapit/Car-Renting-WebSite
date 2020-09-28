using Garage1.Models;
using Garage1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {

            return RedirectToAction("LogFile");

        }
        public ActionResult LogFile() {

            return View(new context().Logs.ToList());

        }

        public ActionResult Statictics() {
            StatitsticsViewModel model = new StatitsticsViewModel();
            context data = new context();

            foreach (var item in data.Cars.ToList()) {
                int numberOfRentedTimes = data.Logs.Count(m => m.carID == item.ID);
                int sum;
                try {
                    var sum1 = (from log in data.Logs
                               where log.carID == item.ID && log.kind == kind.car
                               select log.period
                                ).ToList().Sum();
                    sum = sum1;
                }
                catch(Exception e) {
                    sum = -1;
                }

                if (numberOfRentedTimes > model.NumberOfMostRentedCar) {
                    model.NumberOfMostRentedCar = numberOfRentedTimes;
                    model.MostRentedCar = item;
                }
                if (sum > model.MaxCarProfit) {
                    model.MaxCarProfit = sum*item.PriceForDay;
                    model.CarWithMaxProfit = item;
                }

            }
            Dictionary<int, HashSet<DateTime>> packages = new Dictionary<int, HashSet<DateTime>>();
            foreach (var item in data.Logs) {
                HashSet<DateTime> hash = new HashSet<DateTime>();
                if(item.kind == kind.package) {
                    if (!packages.ContainsKey(item.carID))packages[item.carID] = hash;
                    packages[item.carID].Add(item.date);
                }
            }
            model.NumberOfMostRentedPackage = -1;
            foreach (var item in packages) {
                if (item.Value.Count() > model.NumberOfMostRentedPackage) {
                    model.NumberOfMostRentedPackage = item.Value.Count();
                    model.MostRentedPackage = data.Packages.FirstOrDefault(pack => pack.ID == item.Key);
                }
            }
            if (model.MostRentedPackage == null) {
                model.MostRentedPackage = new Package();
                model.MostRentedPackage = data.Packages.FirstOrDefault(); // remember to remove
                model.NumberOfMostRentedPackage = 0;
            }
            return View(model);
        }
    }
}