using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace Travel.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Byte[] Password { get; set; }
        public string Id { get; set; }
        public List<TravelList> Lists { get; set; }
        public List<Category> Categories { get; set; }

        public User()
        {
            Lists = new List<TravelList>();
            Categories = new List<Category>();
        }

        public User(string name, string email, string password)
        {
            this.Email = email;
            this.Name = name;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            Password = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            Lists = new List<TravelList>();
            Categories = new List<Category>();
        }

        public void AddList(TravelList tl)
        {
            Lists.Add(tl);
        }

        public void AddCategory(Category c)
        {
            Categories.Add(c);
        }
    }
}