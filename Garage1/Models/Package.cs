using Garage1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1 {

    public class Package : IRentable {
        public Action<Object, string , int , long> NewReservation;
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public int Period { get; set; }
        public bool Available { get; set; }
        public string Notes { get; set; }
        public DateTime RentDate { get; set; }
        [Required]
        public double PriceForDay { get; set; }

        public virtual List<Car> Cars { get; set; }
        public virtual List<Client> clients { get; set; }
        public Package() {
            RentDate = new DateTime();
            Available = true;
            Period = 0;
            NewReservation = new LogFile().newReservation;
        }

        public override string ToString() {
            return Title;
        }

        public void PackageIsReserved(long nationalID , int period) {
            foreach (var item in Cars) {
                 NewReservation(this, item.Title , Period , nationalID);
            }
        }

    }
}
