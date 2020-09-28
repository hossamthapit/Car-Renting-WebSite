using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1.Models {
    public interface IRentable {
        [Range(1,1)]
        int ID { get; set; }
        string Title { get; set; }
        bool Available { get; set; }
        double PriceForDay { get; set; }

    }
}
