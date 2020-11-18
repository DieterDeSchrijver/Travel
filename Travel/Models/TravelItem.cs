using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class TravelItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Boolean Completed { get; set; }
        public List<Category> Categories { get; set; }

        public TravelItem()
        {
            
        }

        public TravelItem(string name)
        {
            this.Name = name;
        }

        public TravelItem(string name, List<Category> categories)
        {
            this.Name = name;
            this.Categories = categories;
        }
    }  
}