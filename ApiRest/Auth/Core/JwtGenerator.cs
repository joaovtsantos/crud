using ApiRest.Auth.Interfaces;
using ApiRest.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ApiRest.Auth.Core
{
    public class JwtGenerator : IJwtGenerator
    {
        readonly RsaSecurityKey _key;
        public JwtGenerator(IOptions<AuthSettings> settings)
        {
            RSA privateRSA = RSA.Create();
            privateRSA.ImportRSAPrivateKey(Convert.FromBase64String(settings.Value.PrivateKey), out _);
            _key = new RsaSecurityKey(privateRSA);
        }

        public string CreateUserAuthToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "CRUD Joao",
                Issuer = "AuthService",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
