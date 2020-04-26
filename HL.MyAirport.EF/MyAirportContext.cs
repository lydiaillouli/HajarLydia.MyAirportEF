using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace HL.MyAirport.EF
{
      public class MyAirportContext : DbContext
    {
         public DbSet<Bagage>? Bagages { get; set; }
         public DbSet<Vol>? Vols { get; set; }
        public ILoggerFactory MyLoggerFactory;
        public MyAirportContext(DbContextOptions<MyAirportContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        }
    }
}
