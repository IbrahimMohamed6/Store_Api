using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.TokenService
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key ;


        public TokenServices(IConfiguration configuration)
        {
          _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }
        public string GenerateToken(AppUser appUser)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.GivenName, appUser.Displayname),
                new Claim("UserId", appUser.Id),
                new Claim("UserName", appUser.UserName),
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(Claims),
                Issuer = _configuration["Token:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires=DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds

            };
            var tokenHanddler = new JwtSecurityTokenHandler();
            var token=tokenHanddler.CreateToken(TokenDescriptor);
            return tokenHanddler.WriteToken(token);
            
        }
    }
}
