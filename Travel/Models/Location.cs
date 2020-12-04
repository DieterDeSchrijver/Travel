using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Travel.Models
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float LngCoord { get; set; }
        public float LatCoord { get; set; }
        public string Image { get; set; }

        public Location()
        {

        }

        public Location(string name, float lng, float lat, string image)
        {
            this.Name = name;
            this.LngCoord = lng ;
            this.LatCoord = lat ;
            this.Image = image;
        }      
    }
}