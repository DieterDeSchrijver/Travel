using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Data.Repositories;
using Travel.Models;
using Travel.Models.Requests;
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
            return tls;
        }

        [Authorize(Policy = "User")]
        [HttpGet("{id}")]
        public ActionResult<TravelList> GetTravelList(string id)
        {
            List<TravelList> tls = _us.GetByEmail(User.Identity.Name).Lists;
            TravelList tl = tls.Find(tl => tl.Id == id);
            if (tl == null)
            {
                return BadRequest();
            }
            return tl;
        }

        [HttpPost]
        [Route("CreateTravelList")]
        [Authorize(Policy = "User")]
        public string CreateTravelList(CreateTravelListRequest o)
        {
            Location loc = new Location(o.Name, o.LngCoord, o.LatCoord, o.Image);
            TravelList list = new TravelList(o.Listname, o.StartDate, o.Description, o.EndDate, loc);
            _us.GetByEmail(User.Identity.Name).Lists.Add(list);
            _us.SaveChanges();
            return list.Id;
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize(Policy = "User")]
        public ActionResult DeleteTravelList(string travelListID)
        {

            TravelList tl = _us.GetByEmail(User.Identity.Name).Lists.Find(l => l.Id == travelListID);
            if (tl == null)
            {
                BadRequest("No list found matching the id");
            }
            _us.GetByEmail(User.Identity.Name).Lists.Remove(tl);
            _us.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteItemFromList")]
        [Authorize(Policy = "User")]
        public ActionResult DeleteItemFromList(string travelListID, string itemID)
        {

            TravelList tl = _us.GetByEmail(User.Identity.Name).Lists.Find(l => l.Id == travelListID);
            TravelItem ti = tl.Items.Find(i => i.Id == itemID);
            if (tl == null || itemID == null)
            {
                BadRequest("No list found matching the id");
            }
            _us.GetByEmail(User.Identity.Name).Lists.Find(l => l.Id == tl.Id).Items.Remove(ti);
            _us.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("EditTravelList")]
        [Authorize(Policy = "User")]
        public ActionResult EditTravelList(TravelList tl)
        {
            if (null == _us.GetByEmail(User.Identity.Name).Lists.Find(l => l.Id == tl.Id))
            {
                return BadRequest("Can't find list");
            }
            
            _travelLists.Update(tl);
            _travelLists.SaveChanges();
            return Ok();
        }
    }
}
