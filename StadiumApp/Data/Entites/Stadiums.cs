using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumApp.Data.Entites
{
    internal class Stadiums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyPrice { get; set; }
        public byte Capacity { get; set; }
    }
}
