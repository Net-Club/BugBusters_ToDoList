using AuthorizationServer.Common;
using DataManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

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
        public ReturnModel<string> Post([FromBody] JsonElement JSdata)
        {
            UserModel user;
            try { user = AuthenticateUser(JSdata.GetProperty("name").GetString(), JSdata.GetProperty("password").GetString()); }
            catch { return new ReturnModel<string>(new List<string>() { "" }, 400, "Wrong JS data"); }
            if (user != null)
            {
                string token = GenerateJWT(user);
                if (token == null)
                {
                    return new ReturnModel<string>(new List<string>() { token }, 523, "Bad auth Options");
                }
                else { return new ReturnModel<string>(new List<string>() { token }, 200, "Authorized"); }

            }
            else { return new ReturnModel<string>(new List<string>() { "" }, 401, "UnAuthorized"); }  
        }

        private static UserModel AuthenticateUser(string name, string password)
        {
            List<UserModel> accounts = UserManager.Get();

            if (accounts == null || accounts.Count == 0) { return null; }

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
            if (authParams == null) { return null; }
            SymmetricSecurityKey securityKey = authParams.GetSymmetricSecurityKey();
            if (securityKey == null) { return null; }
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            JwtSecurityToken token = new(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
