using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models;
using Travel.Data;
using Travel.Domain.Models;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Travel.Services
{
    public class UserService
    {
        private DbSet<User> _users;
        private ApplicationDbContext _applicationDbContext;
        private string _key;

        public UserService(ApplicationDbContext context, IAppSettings appSettings)
        {
            _applicationDbContext = context;
            _users = _applicationDbContext.Users;
            _key = appSettings.key;
        }

        public bool AuthorizeAdmin(LoginRequest login)
        {
            User user = _users.SingleOrDefault(u => u.Email == login.Email);
            byte[] password = System.Text.Encoding.ASCII.GetBytes(login.Password);
            password = new System.Security.Cryptography.SHA256Managed().ComputeHash(password);
            return StructuralComparisons.StructuralEqualityComparer.Equals(password, user.Password);
        }

        public string GetToken(string email)
        {
            User user = _users.SingleOrDefault(u => u.Email == email);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, "user"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var ret = tokenHandler.WriteToken(token);
            return ret;
        }

        public User GetByEmail(string email)
        {

            return _users.AsNoTracking().Include(u => u.Lists).ThenInclude(tl => tl.Items).ThenInclude(i => i.Category)
                .Include(u => u.Lists).ThenInclude(tl => tl.Location).Include(u => u.Categories)
                .SingleOrDefault(u => u.Email.Equals(email));
        }

        internal void AddCategory(Category c, string email)
        {
            _users.Single(u => u.Email == email).Categories.Add(c);
        }

        public Boolean EmailAlreadyUsed(string email)
        {
            return _users.Any(u => u.Email == email);
        }

        public void AddUser(User u)
        {
            _users.Add(u);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
