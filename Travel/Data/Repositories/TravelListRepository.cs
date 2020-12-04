using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data.Repositories
{
    public class TravelListRepository : ITravelListRepository
    {
        private ApplicationDbContext _applicationDbContext;
        private DbSet<TravelList> _travelLists;

        public TravelListRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
            _travelLists = _applicationDbContext.TravelLists;
        }

        public List<TravelList> GetAll()
        {
            return _travelLists.Include(tl => tl.Location).Include(tl => tl.Items).ToList();
        }

        public void Update(TravelList tl)
        {
            _travelLists.Remove(_travelLists.Single(t => t.Id == tl.Id));
            _travelLists.Add(tl);
        }

        public TravelList GetOne(string id)
        {
           return  _travelLists.FirstOrDefault(t => t.Id.Equals(id));
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public TravelList Create(TravelList travelList)
        {
            _travelLists.Add(travelList);
            SaveChanges();
            return travelList;
        }

        public void Delete(string travelListId)
        {
            _travelLists.Remove(_travelLists.First(t => t.Id.Equals(travelListId)));
            SaveChanges();
        }

        public void DeleteItemFromList(string travelListID, string itemID)
        {
            var travelList = GetOne(travelListID);
            var item = travelList.Items.FirstOrDefault(i => i.Equals(itemID));
            travelList.Items.Remove(item);
            SaveChanges();
        }
    }
}
