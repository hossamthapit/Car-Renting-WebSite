using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage1.ViewModels {
    public class StatitsticsViewModel {
        public Car MostRentedCar { get; set; }
        public Package MostRentedPackage { get; set; }
        public Car CarWithMaxProfit { get; set; }
        public Package PackageWithMaxProfit { get; set; }
        public int NumberOfMostRentedCar { get; set; }
        public int NumberOfMostRentedPackage { get; set; }
        public double MaxCarProfit { get; set; }
        public double MaxPackageProfit { get; set; }
    }
}