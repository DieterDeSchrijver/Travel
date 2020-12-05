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
        private TravelListService _travelListService;

        public TravelListController(TravelListService travelListService)
        {
            this._travelListService = travelListService;
        }

        //GET
        [Authorize(Policy = "User")]
        [HttpGet]
        public List<TravelList> GetTravelLists()
        {
            return _travelListService.GetAllItemsFromUser(User.Identity.Name);
        }

        [Authorize(Policy = "User")]
        [HttpGet("{id}")]
        public ActionResult<TravelList> GetTravelList(string id)
        {
            TravelList travelList = _travelListService.GetListItemFromUserById(id);
            if (travelList == null)
            {
                return BadRequest();
            }
            return travelList;
        }

        [HttpPost]
        [Route("CreateTravelList")]
        [Authorize(Policy = "User")]
        public string CreateTravelList(CreateTravelListRequest o)
        {
            var loc = new Location(o.Name, o.LngCoord, o.LatCoord, o.Image);
            var list = new TravelList(o.Listname, o.StartDate, o.Description, o.EndDate, loc, User.Identity.Name);
            var id = _travelListService.CreateTravelList(list, User.Identity.Name);
            return list.Id;
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize(Policy = "User")]
        public ActionResult DeleteTravelList(string travelListID)
        {
            var succes = _travelListService.DeleteTravelList(travelListID);
            if (!succes)
            {
                BadRequest("No list found matching the id");
            }
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteItemFromList")]
        [Authorize(Policy = "User")]
        public ActionResult DeleteItemFromList(string travelListID, string itemID)
        {
            var succes = _travelListService.DeleteItemFromList(travelListID, itemID);
            if (!succes)
            {
                BadRequest("No list found matching the id");
            }
            return Ok();
        }

        [HttpPost]
        [Route("EditTravelList")]
        [Authorize(Policy = "User")]
        public ActionResult EditTravelList(TravelList tl)
        {
            var succes = _travelListService.UpdateTravelList(tl);
            if (!succes)
            {
                return BadRequest("Can't find list");
            }
            return Ok();
        }
    }
}
