using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;

namespace Travel.Data.Repositories
{
    interface ITravelListRepository
    {
        List<TravelList> GetAll();
        TravelList GetOne();
    }
}
