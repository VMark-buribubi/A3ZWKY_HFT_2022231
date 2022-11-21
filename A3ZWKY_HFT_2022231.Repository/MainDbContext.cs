using System;
using A3ZWKY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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


    }
}
