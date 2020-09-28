using Garage1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1 {

    public enum Brand {
        Oudi,
        Mercedes,
        KIA,
        Lambourgeny,
        Doddge
    }

    public class Car : IRentable {
        public Action<Object, string, int , long > NewReservation;

        private double priceForDay;
        public int ID { get; set; }
        public int period { get; set; }
        public bool Available { get; set; }
        public DateTime RentDate { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand Is Required")]
        public Brand Brand { get; set; }

        [Display(Name = "Price For Day")]
        [Required(ErrorMessage = "Price Is Required")]
        public double PriceForDay { get { return priceForDay; } set { priceForDay = value; } }

        public virtual List<Client> ClientsList { get; set; }
        public virtual List<Offer> Offers { get; set; }
        public virtual List<Package> Packages { get; set; }

        public Car() {
            Available = true;
            NewReservation += new LogFile().newReservation;
        }
        public string toString() {
            return Title;
        }
        public void CarIsReserved(long nationalID , int period) {
            NewReservation(this, Title, period , nationalID);
        }

    }
}