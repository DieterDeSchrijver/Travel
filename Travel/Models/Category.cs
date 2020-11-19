using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public Category()
        {

        }

        public Category(string name, string icon)
        {
            this.Name = name;
            this.Icon = icon;
        }
    }
}