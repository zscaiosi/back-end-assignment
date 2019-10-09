using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Login.API.Contracts.Views;

namespace Login.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _user;
        private readonly string _password;
        public OAuthController(IConfiguration config)
        {
            _configuration = config;
            _user = _configuration["username"];
            _password = _configuration["password"];
        }
        /// <summary>
        /// Retrieves an access token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public ActionResult<PostAccessTokenResponse> Post([FromBody]PostTokenRequest request)
        {
            // For simplicity's sake I will not implement the authentication process, but just leave a dumb check
            if (request.user != _user || request.password != _password)
                return StatusCode(403);

            // Build Claims
            var claims = new[]{
                new Claim("uid", "123456789"),
                new Claim("scope", "Products.API")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["SecurityKey"])
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expire = DateTime.Now.AddHours(24);

            var token = new JwtSecurityToken(
                issuer: "evoxsolutions",
                audience: "evoxsolutions",
                claims: claims,
                // 1 day should be OK
                expires: expire,
                signingCredentials: credentials
            );

            return StatusCode(200, new PostAccessTokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expire.Millisecond
            });
        }
        [HttpGet]
        public ActionResult Get() =>
            StatusCode(200, "ok!");
    }
}
