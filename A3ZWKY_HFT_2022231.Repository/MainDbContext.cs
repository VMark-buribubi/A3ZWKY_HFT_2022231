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
    public class MainDbContext : DbContext
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
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("Database");
            }
        }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            mod.Entity<Person>()
                .HasOne(x => x.House)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.HouseId);

            mod.Entity<Person>()
                .HasOne(x => x.Workplace)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.WorkplaceId);

            var Houses = new List<House>()
            {
                new House(){HouseId = 1, Color = "Yellow", FloorArea = 200, Address = "1001 Cipő utca 1."},
                new House(){HouseId = 2, Color = "Green", FloorArea = 180, Address = "1001 Cipő utca 2."},
                new House(){HouseId = 3, Color = "Red", FloorArea = 250, Address = "1001 Cipő utca 3."},
                new House(){HouseId = 4, Color = "Cyan", FloorArea = 120, Address = "1001 Cipő utca 4."},
                new House(){HouseId = 5, Color = "Brown", FloorArea = 140, Address = "1001 Cipő utca 5."},
                new House(){HouseId = 6, Color = "White", FloorArea = 165, Address = "1001 Cipő utca 6."}
            };

            var Persons = new List<Person>()
            {
                new Person(){PersonId = 1, Name = "Kiss János", Age = 20, Gender = "Male", BirthDate = new DateTime(2000,05,25), HouseId = 1, WorkplaceId = 1},
                new Person(){PersonId = 2, Name = "Köves Béla", Age = 30, Gender = "Male", BirthDate = new DateTime(1990,10,12), HouseId = 2, WorkplaceId = 4},
                new Person(){PersonId = 3, Name = "Gipsz Jakab", Age = 25, Gender = "Male", BirthDate = new DateTime(1995,06,15), HouseId = 3, WorkplaceId = null},
                new Person(){PersonId = 4, Name = "Édes Anna", Age = 20, Gender = "Female", BirthDate = new DateTime(2000,04,02), HouseId = 1, WorkplaceId = 1},
                new Person(){PersonId = 5, Name = "Erős Pista", Age = 50, Gender = "Male", BirthDate = new DateTime(1970,06,28), HouseId = 4, WorkplaceId = null},
                new Person(){PersonId = 6, Name = "Nagy Eszter", Age = 26, Gender = "Female", BirthDate = new DateTime(1994,09,09), HouseId = 3, WorkplaceId = null},
                new Person(){PersonId = 7, Name = "Domokos Dezső", Age = 60, Gender = "Male", BirthDate = new DateTime(1960,02,12), HouseId = 5, WorkplaceId = 3},
                new Person(){PersonId = 8, Name = "Keresztes Anikó", Age = 28, Gender = "Female", BirthDate = new DateTime(1992,01,21), HouseId = 2, WorkplaceId = 2},
                new Person(){PersonId = 9, Name = "Bíró Kinga", Age = 55, Gender = "Female", BirthDate = new DateTime(1965,03,18), HouseId = 5, WorkplaceId = null},
                new Person(){PersonId = 10, Name = "Papp Tamás", Age = 22, Gender = "Male", BirthDate = new DateTime(1998,04,27), HouseId = 6, WorkplaceId = 4}
            };

            var Workplaces = new List<Workplace>()
            {
                new Workplace(){WorkplaceId = 1, Name = "Búzási Hentes", Type = "Hentes", TelephoneNumber = "20/2836493", Address = "1001 Zokni utca 21.",},
                new Workplace(){WorkplaceId = 2, Name = "Friss Pékség", Type = "Pékség", TelephoneNumber = "70/3456224", Address = "'1001 Zokni utca 12.",},
                new Workplace(){WorkplaceId = 3, Name = "Talpaló Cipészet", Type = "Cipészet", TelephoneNumber = "30/4957464", Address = "'1001 Zokni utca 32.",},
                new Workplace(){WorkplaceId = 4, Name = "Napsugár Hipermarket", Type = "Hipermarket", TelephoneNumber = "20/1249867", Address = "'1001 Zokni utca 7.",},
            };

            mod.Entity<House>().HasData(Houses);
            mod.Entity<Workplace>().HasData(Workplaces);
            mod.Entity<Person>().HasData(Persons);
        }

    }
}
