using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Data.Repositories;
using Travel.Models;
using Travel.Services;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelListController : ControllerBase
    {
        private TravelListRepository _travelLists;
        private UserService _us;

        public TravelListController(TravelListRepository travelLists, UserService us)
        {
            this._travelLists = travelLists;
            this._us = us;
        }

        //GET
        [Authorize(Policy = "User")]
        [HttpGet]
        public List<TravelList> GetTravelLists()
        {
            List<TravelList> tls = _us.GetByEmail(User.Identity.Name).Lists;
            return _travelLists.GetAll();
        }

        
    }
}
