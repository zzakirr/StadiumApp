using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumApp.Data.Entites
{
    internal class Reservations
    {
        public int Id { get; set; }
        public int StadionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Users User { get; set; }
        public Stadiums Stadion { get; set; }


    }
}
