using Microsoft.EntityFrameworkCore;
using StadiumApp.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumApp.Data.DAL
{
    internal class StadiumsDbContext:DbContext
    {
        public DbSet<Stadiums> Stadiums { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Reservations> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-3R9ERVR\SQLEXPRESS; Database = StadiumApp;Trusted_Connection = TRUE;");
        }
    }
}
