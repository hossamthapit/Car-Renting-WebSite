using Garage1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Garage1 {
    public class context : DbContext {

        public context() : base("name=Garage1") {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogFile> LogFile { get; set; }

    }
}
