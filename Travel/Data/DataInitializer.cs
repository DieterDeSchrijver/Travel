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

            if (_dbContext.Database.EnsureCreated())
            {
                #region<Rome>
                List<TravelItem> rome = new List<TravelItem>();
                TravelItem ti1 = new TravelItem("Kousen");
                rome.Add(ti1);
                TravelItem ti2 = new TravelItem("T-Shirts");
                rome.Add(ti2);
                TravelItem ti3 = new TravelItem("Sweater");
                rome.Add(ti3);
                TravelItem ti4 = new TravelItem("Broek");
                rome.Add(ti4);
                TravelItem ti5 = new TravelItem("Loopschoenen");
                rome.Add(ti5);
                TravelItem ti6 = new TravelItem("Sneakers");
                rome.Add(ti6);

                Category c1 = new Category("Sport", "SportIcon");
                Category c2 = new Category("Kledij", "KledijIcon");
                Category c3 = new Category("Schoenen", "SchoenenIcon");

                ti1.Category = c1;
                ti2.Category = c2;
                ti3.Category = c3;
                ti4.Category = c1;
                ti5.Category = c2;
                ti6.Category = c3;

                float[] coords = { (float)3.0230, (float)51.012312 };

                TravelList tl1 = new TravelList("Lijst Rome", DateTime.Now,"Joepiee!!!!!!!",  DateTime.Now, new Location("Rome", coords[0], coords[1], "https://images.unsplash.com/photo-1473496169904-658ba7c44d8a?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=1650&q=80"), "1");
                tl1.AddItems(rome);
                #endregion

                List<TravelItem> parijs = new List<TravelItem>();
                TravelItem t1 = new TravelItem("Kousen");
                t1.Completed = true;
                parijs.Add(t1);
                TravelItem t2 = new TravelItem("T-Shirts");
                t2.Completed = true;
                parijs.Add(t2);
                TravelItem t3 = new TravelItem("Sweater");
                t3.Completed = true;
                parijs.Add(t3);
                TravelItem t4 = new TravelItem("Broek");
                t4.Completed = true;
                parijs.Add(t4);
                TravelItem t5 = new TravelItem("Loopschoenen");
                t5.Completed = true;
                parijs.Add(t5);
                TravelItem t6 = new TravelItem("Sneakers");
                t6.Completed = true;
                parijs.Add(t6);

                t1.Category = c1;
                t2.Category = c2;
                t3.Category = c3;
                t4.Category = c1;
                t5.Category = c2;
                t6.Category = c3;

                float[] coord = { (float)2.349014, (float)48.864716 };

                TravelList tlp = new TravelList("Lijst Parijs", DateTime.Now, "Joepiee!!!!!!!", DateTime.Now, new Location("Parijs", coord[0], coord[1], "https://images.unsplash.com/photo-1440778303588-435521a205bc?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=1650&q=80"), "tijldeblander@gmail.com");
                tlp.AddItems(parijs);

                User user = new User("Dieter", "dieter@gmail.com", "test");
                user.AddList(tlp);
                user.AddList(tl1);
                user.AddCategory(c1);
                user.AddCategory(c2);
                user.AddCategory(c3);


                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

            }
        }

    }
}
