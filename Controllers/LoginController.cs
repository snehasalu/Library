using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1 Dependency injection for configuration
        private readonly IConfiguration _config;
        private object Configuration;

        //2 Constructor Injection
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        //3 HttpPost
        [HttpPost("token")]
        
        public IActionResult Login([FromBody] Membermodel user)
        {
            //check Unautherised or not
            IActionResult response = Unauthorized();

            //authenticate user 
            var loginUser = AuthenticateUser(user);
            //return Ok("Hello from API");

            //Validate the user and generate JWT Token
            if(loginUser != null)
            {
               var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }
            return response;
        }


        //4Authenticate User
        private Membermodel AuthenticateUser(Membermodel user)
        {
            Membermodel loginUser = null;

            //Validate the User Credentials
            //Retrieve data from the database
            if(user.Membername == "Ashwin")
            {
                loginUser = new Membermodel
                {
                    Membername = user.Membername
                };
            }
            return loginUser;
        }


        //5Generate JWT Token
        private object GenerateJWToken(Membermodel loginUser)
        {
            //SecurityKey 
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //Signinf Credential
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            //claims --Roles


            //Generate TOken
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],//Header
                _config["Jwt:Issuer"],//payload
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials : credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
