using Garage1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1.Controllers
{
    public class CarController : Controller
    {
        
        [HttpGet]
        public ActionResult AddCar() {

            return (View());
        }
        [HttpPost]
        public ActionResult AddCar(Car car) {

            context data = new context();

            car.RentDate = DateTime.Today;
            car.period = 0;
            data.Cars.Add(car);
            data.SaveChanges();

            return RedirectToAction("ShowCarsCards");
        }
        public ActionResult EditCar(int ID) {

            context data = new context();

            return View(data.Cars.FirstOrDefault(ca => ca.ID == ID));
        }
        [HttpPost]
        public ActionResult EditCar(int ID , Car car) {

            context data = new context();

            Car tempCar = data.Cars.FirstOrDefault(ca => ca.ID == ID);

            tempCar.Title = car.Title;
            tempCar.Brand = car.Brand;
            tempCar.PriceForDay = car.PriceForDay;

            data.SaveChanges();

            return RedirectToAction("ShowCarsCards");
        }
        public ActionResult ShowCars() {

            context data = new context();

            return View(data.Cars.ToList());
        }

        public ActionResult ShowCarsCards(string id = "") {
            context data = new context();
            List<Car> list;

            int idint = -1;
            try {
                idint = int.Parse(id);
            }
            catch (Exception e) {
                idint = -1;
            }

            if (id == "") list = data.Cars.ToList();
            else if(idint != -1) {
                list = data.Cars.Where(car => car.ID == idint).ToList();
            }
            else {
                Brand brand = (Brand)Enum.Parse(typeof(Brand),id);
                list = data.Cars.Where(car => car.Brand == brand).ToList();
            }
            return View(list);

        }

        [HttpGet]
        public ActionResult ReserveCar(int ID) {

            context data = new context();

            ClientReserveCarViewModel viewModel = new ClientReserveCarViewModel();

            viewModel.CarID = ID;
            viewModel.CarName = data.Cars.FirstOrDefault(i => i.ID == ID).Title;

            TempData["ID"] = ID; // not working 

            return View();
        }

        [HttpPost]
        public ActionResult ReserveCar(int id , ClientReserveCarViewModel ViewModel) {
            ViewModel.CarID = id;

            context data = new context();

            data.Cars.FirstOrDefault(ca => ca.ID == ViewModel.CarID).RentDate = DateTime.Today;

            data.Cars.FirstOrDefault(ca => ca.ID == ViewModel.CarID).period = ViewModel.Period;

            data.Cars.FirstOrDefault(ca => ca.ID == ViewModel.CarID).CarIsReserved(ViewModel.NationalId,ViewModel.Period);

            if (data.Clients.FirstOrDefault(cli => cli.ssn == ViewModel.NationalId) != null) {
                data.Clients.FirstOrDefault(cli => cli.NationalId == ViewModel.NationalId).RentedCarsHistory.Add(data.Cars.FirstOrDefault(ca => ca.ID == ViewModel.CarID));
            }
            else {
                Client client = new Client {
                    ssn = ViewModel.NationalId,
                    NationalId = ViewModel.NationalId,
                    City = ViewModel.City,
                    Country = ViewModel.Country,
                    Street = ViewModel.Street,
                    FirstName = ViewModel.FirstName,
                    LastName = ViewModel.LastName,
                    Phone = ViewModel.Phone
                };

                if (client.RentedCarsHistory == null)
                    client.RentedCarsHistory = new List<Car>();

                client.RentedCarsHistory.Add(data.Cars.FirstOrDefault(ca => ca.ID == ViewModel.CarID));

                data.Clients.Add(client);
            }
            data.SaveChanges();

            if (ModelState.IsValid) {
                return RedirectToAction("ShowCarsCards");
            }
            else {
                return RedirectToAction("AddCar");
            }
        }

        public ActionResult deletecar(int id) {

            context data = new context();

            Car c = data.Cars.FirstOrDefault(cc => id == cc.ID);

            data.Cars.Remove(c);

            data.SaveChanges();

            return RedirectToAction("ShowCarsCards");
        }
        public ActionResult showCarHistory(int id) {
            return View(new context().Cars.FirstOrDefault(c=>c.ID==id).ClientsList.ToList());
        }
    }
}