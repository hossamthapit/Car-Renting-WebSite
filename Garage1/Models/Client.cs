using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1 {
    public class Client {

        private long phone;
        private long nationalId;
        [Key]
        public long NationalId { get { return nationalId; } set { nationalId = value; } }
        public long ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        public long Phone { get { return phone; } set { phone = value; } }

        public int Period { get; set; }
        public virtual List<Car> RentedCarsHistory { get; set; }
        public virtual List<Package> RentedPackagesHistory { get; set; }
        public virtual List<Offer> TakenOffers { get; set; }

        //public double calculateTotalPurshase() {
        //    double total = 0;
        //    foreach (var item in _rentingHistoryList) {
        //        total += item._period * item.car._priceForDay;
        //    }
        //    return total;
        //}


    }
}
