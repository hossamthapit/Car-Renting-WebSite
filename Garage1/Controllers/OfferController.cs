using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage1.Controllers
{
    public class OfferController : Controller
    {
        public ActionResult AddOffer() {

            return View();

        }
        [HttpPost]
        public ActionResult AddOffer(Offer offer) {

            context data = new context();
            data.Offers.Add(offer);
            data.SaveChanges();

            return RedirectToAction("ShowOffersCards");

        }
        public ActionResult ShowOffers() {

            return View(new context().Offers.ToList());

        }
        public ActionResult ShowOffersCards() {

            return View(new context().Offers.ToList());

        }
        public ActionResult DeleteOffer(int id) {

            context data = new context();
            Offer offer = data.Offers.FirstOrDefault(o => o.ID == id);
            data.Offers.Remove(offer);
            data.SaveChanges();

            return RedirectToAction("ShowOffersCards");

        }
    }
}