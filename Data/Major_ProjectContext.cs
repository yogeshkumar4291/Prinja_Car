using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prinja_Car.Models;

namespace Prinja_Car.Data
{
    public class Major_ProjectContext : DbContext
    {
        public Major_ProjectContext (DbContextOptions<Major_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Prinja_Car.Models.Customer> Customer { get; set; }

        public DbSet<Prinja_Car.Models.Staff> Staff { get; set; }

        public DbSet<Prinja_Car.Models.Car> Car { get; set; }

        public DbSet<Prinja_Car.Models.Store> Store { get; set; }

        public DbSet<Prinja_Car.Models.Buy> Buy { get; set; }
    }
}
