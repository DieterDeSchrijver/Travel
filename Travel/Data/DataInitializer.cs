using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                List<TravelItem> tis = new List<TravelItem>();
                TravelItem ti1 = new TravelItem("Kousen");
                tis.Add(ti1);
                TravelItem ti2 = new TravelItem("T-Shirts");
                tis.Add(ti2);
                TravelItem ti3 = new TravelItem("Sweater");
                tis.Add(ti3);
                TravelItem ti4 = new TravelItem("Broek");
                tis.Add(ti4);

                double[] coords = { 100, 200 };

                TravelList tl1 = new TravelList("Lijst Rome", DateTime.Now, DateTime.Now, new Location("Rome", coords[0], coords[1], DateTime.Now));
                tl1.AddItems(tis);

                _dbContext.TravelLists.Add(tl1);
                _dbContext.SaveChanges();

            }
        }
    }
}
