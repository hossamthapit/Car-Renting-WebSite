using Garage1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1 {
    public class Offer {
        public int ID { get; set; }

        [Required(ErrorMessage ="Title Is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Just Use English Alphabet")]
        public string Title { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Discount Is Required")]
       // [RegularExpression(@"5|10|15|20|25|30|35|40|50|45", ErrorMessage = "Number Must Be Divisable By 5")]  doesn't work with 50 ?? 
        public double Discount { get; set; }

        [Required(ErrorMessage = "Limit Is Required")]
        [Display(Name ="Min Limit")]
        public int Limit { get; set; }
        public virtual List<Client> Clients { get; set; }
        public string toString() {
            return Title;
        }


    }
}
