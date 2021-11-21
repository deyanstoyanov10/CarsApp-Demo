namespace CarsApp.Services.Authentication
{
    using Authentication.Contracts;

    using CarsApp.Common;
    using CarsApp.Data.Models;

    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using System;
    using System.Linq;
    using System.Text;
    using System.Security.Claims;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;

    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly AppSettings applicationSettings;

        public TokenGeneratorService(IOptions<AppSettings> applicationSettings)
            => this.applicationSettings = applicationSettings.Value;

        public string GenerateToken(AppUser user, IEnumerable<string> roles = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            if (roles != null)
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
