using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage1.Models {
    public class Log {
        public int Id { get; set; }
        public String MSG { get; set; }
        public kind kind { get; set; }
        public DateTime date { get; set; }
        public int period { get; set; }
        public long nationalID { get; set; }
        public virtual LogFile log { get; set; }
        public int carID { get; set; }
    }
}