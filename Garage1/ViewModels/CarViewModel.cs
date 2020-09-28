using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage1.ViewModels {
    public class CarViewModel {

        private double priceForDay;
        public int ID { get; set; }
        [Range(1, 10)]
        public int period { get; set; }
        public bool Available { get; set; }
        public DateTime RentDate { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand Is Required")]
        [RegularExpression(@"\D+", ErrorMessage = "Just Use English Alphabet")]
        public Brand Brand { get; set; }

        [Display(Name = "Price For Day")]
        [Required(ErrorMessage = "Price Is Required")]
        public double PriceForDay { get { return priceForDay; } set { priceForDay = value; } }
    }
}