using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Models.Requests
{
    public class CreateTravelListRequest
    {
        public string Listname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public float LngCoord { get; set; }
        public float LatCoord { get; set; }
        public string Image { get; set; }

        public CreateTravelListRequest(string listname, DateTime startDate, DateTime endDate, string description, string name, float lngCoord, float latCoord, string image)
        {
            Listname = listname;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Name = name;
            LngCoord = lngCoord;
            LatCoord = latCoord;
            Image = image;
        }
    }

    
}
