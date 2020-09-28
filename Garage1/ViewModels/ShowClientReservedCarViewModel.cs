using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage1.ViewModels {
    public class ShowClientReservedCarViewModel {
        public List<Package> packages { get; set; }
        public List<Car> cars { get; set; }
    }
}