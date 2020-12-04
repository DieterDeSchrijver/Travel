using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data.Repositories
{
    public interface ITravelListRepository
    {
        List<TravelList> GetAll();
        TravelList GetOne(String id);

        TravelList Create(TravelList travelList);

        void Delete(string travelListId);
        void Update(TravelList tl);
        void DeleteItemFromList(string travelListID, string itemID);
    }
}
