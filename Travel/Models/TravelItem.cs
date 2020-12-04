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
        public Category Category { get; set; }

        public TravelItem()
        {
            
        }

        public TravelItem(string name)
        {
            this.Name = name;
        }

        public TravelItem(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }
    }  
}