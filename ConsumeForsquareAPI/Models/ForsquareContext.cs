using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Models
{
    public class ForsquareContext : DbContext
    {
        public ForsquareContext(DbContextOptions<ForsquareContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Place> Places { get; set; }
        

    }
}
