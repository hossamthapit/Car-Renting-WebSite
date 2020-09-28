using Garage1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1.Controllers
{
    public class PackageController : Controller
    {
        public ActionResult AddPackage() {
            return View();
        }
        [HttpPost]
        public ActionResult AddPackage(int car1_id, int car2_id, int car3_id, Package package) {

            context data = new context();
            Car c1 = data.Cars.FirstOrDefault(m => m.ID == car1_id);
            Car c2 = data.Cars.FirstOrDefault(m => m.ID == car2_id);
            Car c3 = data.Cars.FirstOrDefault(m => m.ID == car3_id);
            c1.period = 0;
            c2.period = 0;
            c3.period = 0;

            if (package.Cars == null)
                package.Cars = new List<Car>();

            package.RentDate = DateTime.Today;
            package.Cars.Add(c1);
            package.Cars.Add(c2);
            package.Cars.Add(c3);

            data.Packages.Add(package);
            data.SaveChanges();

            return RedirectToAction("ShowPackageCards");
        }
        public ActionResult ShowPackage() {

            return View(new context().Packages.ToList());

        }
        public ActionResult ShowPackageCards(string id="") {
            context data = new context();
            List<Package> list;

            int idint = -1;
            try {
                idint = int.Parse(id);
            }
            catch (Exception e) {
                idint = -1;
            }

            if (id == "") list = data.Packages.ToList();
            else if (idint != -1) {
                list = data.Packages.Where(pack => pack.ID == idint).ToList();
            }
            else {
                Brand brand = (Brand)Enum.Parse(typeof(Brand), id);
                list = data.Packages.Where(pack => pack.Title == id).ToList();
            }
            return View(list);
        }
        public ActionResult DeletePackage(int id) {

            context data = new context();
            List<Package> list = data.Packages.ToList();

            data.Packages.Remove(data.Packages.FirstOrDefault(pack => pack.ID == id));
            data.SaveChanges();

            return RedirectToAction("ShowPackageCards");

        }

        public ActionResult reservePackage(int id) {

            context data = new context();

            ClientReservePackageViewModel viewmodel = new ClientReservePackageViewModel();

            viewmodel.PackageName = data.Packages.FirstOrDefault(p => id == p.ID).Title;
            viewmodel.PackageId = data.Packages.FirstOrDefault(p => id == p.ID).ID;
            TempData["ID"] = id;

            return View();
        }
        [HttpPost]
        public ActionResult reservePackage(int id , ClientReservePackageViewModel model) {
            model.PackageId = id;
            context data = new context();

            Client client = new Client {
                ssn = model.NationalId,
                City = model.City,
                Country = model.Country,
                Street = model.Street,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone
            };
            if (client.RentedPackagesHistory == null)   
                client.RentedPackagesHistory = new List<Package>();

            client.RentedPackagesHistory.Add(data.Packages.FirstOrDefault(pack => pack.ID == model.PackageId));
            data.Clients.Add(client);

            data.SaveChanges();

            context data1 = new context();
            Package p = data1.Packages.FirstOrDefault(ca => ca.ID == model.PackageId);

            for( int i = 0; i < 3;i++) {
                p.Cars[i].period = model.Period;
                p.Cars[i].RentDate = DateTime.Today;
                p.Cars[i].ClientsList.Add(data1.Clients.FirstOrDefault(cl => cl.NationalId == model.NationalId));
            }

            p.PackageIsReserved(model.NationalId , model.Period);

            p.Period = model.Period;

            data1.SaveChanges();

            return RedirectToAction("ShowPackageCards");
        }



    }
}