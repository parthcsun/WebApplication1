﻿/*
using hotel_management;
using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;    
    
namespace JWTAuthentication.Controllers    
{    
    [Route("api/[controller]")]    
    [ApiController]    
    public class LoginController : Controller    
    {    
        private IConfiguration _config;    
    
        public LoginController(IConfiguration config)    
        {    
            _config = config;    
        }

        public IEmployeeService employeeService;

        public LoginController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [AllowAnonymous]    
        [HttpPost]    
        public IActionResult Login([FromBody] Employee login)    
        {    
            IActionResult response = Unauthorized();    
            var user = AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { token = tokenString });    
            }    
    
            return response;    
        }    
    
        private string GenerateJSONWebToken(Employee userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        private Employee AuthenticateUser(Employee login)    
        {
            Employee user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information
            //

            var employee = employeeService.GetByEmployeeId(employeeId);

            if (login.EmployeeId == "Jignesh")    
            {    
                user = new Employee { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };    
            }    
            return user;    
        }    
    }    
} 

*/