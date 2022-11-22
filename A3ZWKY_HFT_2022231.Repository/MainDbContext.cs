using System;
using A3ZWKY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Globalization;

namespace A3ZWKY_HFT_2022231.Repository
{
    internal class MainDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

        public MainDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Main.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            mod.Entity<Person>()
                .HasOne(x => x.House)
                .WithMany(x => x.Persons);

            mod.Entity<Person>()
                .HasOne(x => x.Workplace)
                .WithOne(x => x.Persons);


             var Houses = new List<House>()
            {
              
            };

            var Workplaces = new List<Workplace>()
            {

            };

            var Persons = new List<Person>()
            {
                
            };

            //mod.Entity<Person>().HasData(Persons);
            mod.Entity<House>().HasData(Houses);
            mod.Entity<Workplace>().HasData(Workplaces);
        }

    }
}
