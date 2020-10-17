using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using StepCore.Entities;
using StepCore.Framework.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StepCore.Framework.Security
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly JwtSettings _jwtConfig;

        public JwtAuthenticationManager(JwtSettings jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        public string Authenticate(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = GetSigningCredentials(tokenKey)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsIdentity GetClaimsIdentity(Users user)
        {
            var roles = string.Join(", ", user.Roles);
            return new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, roles)
            });
        }

        public SigningCredentials GetSigningCredentials(byte[] tokenKey)
        {
            return new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
