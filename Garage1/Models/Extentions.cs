using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage1.Models {
    public static class Extentions {
        public static bool carIsAvailable(this Car c) {
            DateTime endDate = c.RentDate.AddDays(c.period);
            if (DateTime.Today >= endDate)
                return true;
            else
                return false;
        }
        public static bool packageIsAvailable(this Package p) {

            foreach (var item in p.Cars) {
                if (!item.carIsAvailable())
                    return false;
            }
            return true;
        }

        public static double clientTotalPurchase(this Client c) {
            double tot = 0;
            foreach (var item in c.RentedPackagesHistory)
                tot += item.PriceForDay*item.Period;
            foreach (var item in c.RentedCarsHistory)
                tot += item.PriceForDay*item.period;
            return tot;
        }


    }
}