using Garage1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult ShowClients() {

            return View(new context().Clients.ToList());

        }
        public ActionResult ShowClientsCards(string id = "SelectAll") {
            context data = new context();
            List<Client> list;
            bool isInt = true;
            foreach (var item in id) {
                if (item < '0' && item > '9') isInt = false;
            }
            if (id.Length == 14&&isInt) {
                long nationalid = long.Parse(id);
                list = data.Clients.Where(c => c.ssn == nationalid).ToList();
            }
            else if (id == "SelectAll")
                list = data.Clients.ToList();
            else
                list = data.Clients.Where(c => (c.FirstName.Contains(id) || c.LastName.Contains(id) ) ).ToList();

            return View(list);

        }
        public ActionResult ShowReservedCars(int id) {

            ShowClientReservedCarViewModel vi = new ShowClientReservedCarViewModel();

            vi.cars = new context().Clients.FirstOrDefault(m => m.NationalId == id).RentedCarsHistory.ToList();

            vi.packages = new context().Clients.FirstOrDefault(m => m.NationalId == id).RentedPackagesHistory.ToList();

            return View(vi);
        }
    }
}