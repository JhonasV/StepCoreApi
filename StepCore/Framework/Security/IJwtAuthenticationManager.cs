using Microsoft.IdentityModel.Tokens;
using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StepCore.Framework.Security
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(Users user);
        ClaimsIdentity GetClaimsIdentity(Users user);
        SigningCredentials GetSigningCredentials(byte[] tokenKey);
    }
}
