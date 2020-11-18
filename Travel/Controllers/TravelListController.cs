using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Data.Repositories;
using Travel.Models;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelListController : ControllerBase
    {
        public TravelListRepository _travelLists;

        public TravelListController(TravelListRepository travelLists)
        {
            this._travelLists = travelLists;
        }

        //GET
        [HttpGet]
        public List<TravelList> GetTravelLists()
        {
            return _travelLists.GetAll();
        }
    }
}
