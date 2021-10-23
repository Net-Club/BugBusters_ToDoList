using AuthorizationServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using AuthorizationServer.Common;

namespace AuthorizationServer.Controllers
{
    [Route("/auth/authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IOptions<AuthOptions> authOptions;

        public AuthorizationController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }

        [HttpPost]
        public ReturnModel Post([FromBody] JsonElement JSdata)
        {

            UserModel user = AuthenticateUser(JSdata.GetProperty("name").GetString(), JSdata.GetProperty("password").GetString());
            if (user != null)
            {
                string token = GenerateJWT(user);

                return new ReturnModel(token , 200, "Authorized", new List<string>());
            }
            else
            {
                return new ReturnModel(null, 401, "UnAuthorized", new List<string>() { "wrong password or email" });
            }
        }

        private UserModel AuthenticateUser(string name, string password)
        {
            List<UserModel> accounts = DataManager.Get();

            for (int i = 0; i < accounts.Count; i++)
            {
                if (name == accounts[i].Name && password == accounts[i].Password)
                {
                    return accounts[i];
                }
            }
            return null;
        }

        private string GenerateJWT(UserModel user)
        {
            AuthOptions authParams = authOptions.Value;

            SymmetricSecurityKey securityKey = authParams.GetSymmetricSecurityKey();
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim (JwtRegisteredClaimNames.Email, user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
