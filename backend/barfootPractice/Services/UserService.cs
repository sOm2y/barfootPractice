using barfootPractice.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace barfootPractice.Services
{
    public interface IUserService
    {
        Staff Authenticate(string username, string password);
        Staff GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly BarfootContext _context;
        private readonly IConfiguration _configuration;

        public UserService(BarfootContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Staff Authenticate(string username, string password)
        {
            try
            {
                var user = _context.Staffs.SingleOrDefault(x => x.Username == username && x.Password == password);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Secret"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.StaffId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    //Set token expires in 7 days
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public Staff GetById(int id)
        {
            var user = _context.Staffs.FirstOrDefault(x => x.StaffId == id);

            // return user without password
            if (user != null)
                user.Password = null;

            return user;
        }
    }
}
