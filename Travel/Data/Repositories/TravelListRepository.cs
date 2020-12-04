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
            return _travelLists.AsNoTracking().Include(tl => tl.Location).Include(tl => tl.Items).ToList();
        }

        public void Update(TravelList tl)
        {
            _travelLists.Update(tl);
        }

        public TravelList GetOne()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
