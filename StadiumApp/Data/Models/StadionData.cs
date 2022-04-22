using StadiumApp.Data.DAL;
using StadiumApp.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumApp.Data.Models
{
    internal class StadionData
    {
        public void AddStadion(Stadiums stadium)
        {
            StadiumsDbContext stadiumsDbContext = new StadiumsDbContext();
            stadiumsDbContext.Stadiums.Add(stadium);
            stadiumsDbContext.SaveChanges();
        }
        
    }
}
