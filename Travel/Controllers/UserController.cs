using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Travel.Domain.Models;
using Travel.Models;
using Travel.Models.Requests;
using Travel.Services;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginRequest login)
        {
            if (!_userService.EmailAlreadyUsed(login.Email))
                return BadRequest("This email is not connected to an account");
            if (_userService.AuthorizeAdmin(login))
            {
                return Ok(JsonSerializer.Serialize(_userService.GetToken(login.Email)));
            }
            return BadRequest("Email and password do not match");
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterRequest regreq)
        {
            if(_userService.EmailAlreadyUsed(regreq.Email))
                return BadRequest("This email is already in use");
            User u = new User(regreq.Name, regreq.Email, regreq.Password);
            _userService.AddUser(u);
            _userService.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = u.Id }, u);
        }

        public ActionResult<User> GetUser(string email)
        {
            User user = _userService.GetByEmail(email);
            if (user == null) return NotFound();
            return user;
        }

        [HttpGet]
        [Route("GetCategories")]
        [Authorize(Policy = "User")]
        public ActionResult<List<Category>> GetCategories()
        {
            return _userService.GetByEmail(User.Identity.Name).Categories.ToList();
        }

    }
}
