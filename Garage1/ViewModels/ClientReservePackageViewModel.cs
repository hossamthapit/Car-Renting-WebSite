using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage1.ViewModels {
    public class ClientReservePackageViewModel {
        [Required(ErrorMessage = "National ID Is Reuired")]
        [RegularExpression(@"\d{14}" , ErrorMessage ="Must Be 14 Numbers")]
        [Display(Name ="National ID")]
        public long NationalId { get; set; }
        [Required(ErrorMessage = "First Name Is Reuired")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Name Must Contain Only Characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Reuired")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Name Must Contain Only Characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Country Is Reuired")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Country Must Contain Only Characters")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City Is Reuired")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The City Must Contain Only Characters")]
        public string City { get; set; }
        [Required(ErrorMessage ="Street Is Reuired")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Phone Is Reuired")]
        [RegularExpression(@"\d{11}" , ErrorMessage ="Must Be 11 Numbers")]
        public long Phone { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        [Display(Name = "Period In Days")]
        [Required(ErrorMessage ="Period Is Required")]
        [Range(1,10,ErrorMessage ="Period Must Be Between 1 & 10")]
        public int Period { get; set; }


    }
}