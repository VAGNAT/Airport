using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class PlaneContext : DbContext
    {
        public PlaneContext(DbContextOptions<PlaneContext> options) : base(options)
        {

        }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<AirCompany> AirCompanies { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
    }
}
