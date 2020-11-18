using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double LngCoord { get; set; }
        public double LatCoord { get; set; }
        public DateTime LocalTime { get; set; }
        public string Image { get; set; }

        public Location()
        {

        }

        public Location(string name, double lng, double lat, DateTime localTime)
        {
            this.Name = name;
            this.LngCoord = lng ;
            this.LatCoord = lat ;
            this.LocalTime = localTime;
        }
    }
}