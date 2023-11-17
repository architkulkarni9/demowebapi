using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace jwt.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController:ControllerBase{
    
    [HttpPost]
    public IActionResult Login([FromBody] LoginModel user){
        if(user is null){
            return BadRequest("Invalid Client request");
        }
        if(user.UserName=="Tom" && user.Password=="Jerry"){
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var TokenOptions=new
        }
    }
}
