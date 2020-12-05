using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;
using Travel.Data;
using System;
using Travel.Data.Repositories;

namespace Travel.Services
{
    public class TravelListService
    {
        private ITravelListRepository _travelListRepository;
        public TravelListService(ITravelListRepository travelListRepository)
        {
            _travelListRepository = travelListRepository;
        }

        public List<TravelList> GetAllItemsFromUser(string userMail)
        {
            return _travelListRepository.GetAll().Where(t => t.UserName.Equals(userMail)).ToList();
        }

        public TravelList GetListItemFromUserById(string id)
        {
            return _travelListRepository.GetAll().Where(tl =>  tl.Id.Equals(id)).FirstOrDefault();
        }

        public String CreateTravelList(TravelList list, string name)
        {
            list.UserName = name;
            var x = _travelListRepository.Create(list);
            return x.Id;
        }

        public bool DeleteTravelList(string travelListID)
        {
            try
            {
                _travelListRepository.Delete(travelListID);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteItemFromList(string travelListID, string itemID)
        {
            try
            {

                _travelListRepository.DeleteItemFromList(travelListID, itemID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool UpdateTravelList(TravelList tl)
        {
            try
            {
                _travelListRepository.Update(tl);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}

