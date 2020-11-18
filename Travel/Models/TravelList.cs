using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Travel.Models
{
    public class TravelList
    {
        public string Id { get; set; }
        public string Listname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public List<TravelItem> Items { get; set; }

        public TravelList()
        {

        }

        public TravelList(string name, DateTime startDate, DateTime endDate, Location location)
        {
            this.Listname = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Location = location;
            this.Items = new List<TravelItem>();
        }

        public void SetDestription(string description)
        {
            this.Description = description;
        }

        public void AddItem(TravelItem item)
        {
            Items.Add(item);
        }

        public void DeleteItem(TravelItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Items.Contains(item))
                Items.Remove(item);
        }

        public void AddItems(List<TravelItem> list)
        {
            Items.AddRange(list);
        }
    }
}