using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Travel.Domain.Models;
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

        [Route("Register")]
        public ActionResult Register(RegisterRequest regreq)
        {
            if(_userService.EmailAlreadyUsed(regreq.Email))
                return BadRequest("This email is already in use");
            
        }

    }
}
