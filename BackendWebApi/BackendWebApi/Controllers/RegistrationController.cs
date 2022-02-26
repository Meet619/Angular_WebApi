using BackendWebApi.Context;
using BackendWebApi.Jwt;
using BackendWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private ApplicationDbContext _appDbContext;
        private readonly IJwtAuth _jwtAuth;
        public RegistrationController(ApplicationDbContext appDbContext, IJwtAuth jwtAuth)
        {
            _appDbContext = appDbContext;
            _jwtAuth = jwtAuth;
        }

        [HttpGet]
        [Route("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<Register> registers = await _appDbContext.Registration.ToListAsync();
                if (registers == null)
                    return NotFound();
                return Ok(registers);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<IActionResult> CreateUser(Register register)
        {
            try
            {
                if (register == null)
                    return BadRequest();
                var user = _appDbContext.Registration.Where(x => x.UserName == register.UserName).FirstOrDefault();
                if (user == null)
                {
                    await _appDbContext.Registration.AddAsync(register);
                    await _appDbContext.SaveChangesAsync();
                    return Ok("Registration SuccessFull");
                }
                else
                {
                    return BadRequest("UserName Already Exists.Try Something Different.");
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login login)
        {
            try
            {
                if (login == null)
                    return BadRequest();
                var user = _appDbContext.Registration.Where(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password)).FirstOrDefault();
                if (user != null)
                {
                    return Ok("Login SuccessFull");
                }
                else
                {
                    return BadRequest("Login UnsuccessFull");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Try Code
        [AllowAnonymous]
        [HttpPost]
        [Route("authlogin")]
        public IActionResult AuthLogin(Login login)
        {
            try
            {
                if (login == null)
                    return BadRequest();
                Register user = _appDbContext.Registration.Where(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password)).FirstOrDefault();
                if (user == null)
                    return Unauthorized();
                string token = _jwtAuth.Authentication(user.UserName);
                AuthLogin authLogin = new AuthLogin
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Token = token
                };

                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(authLogin);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("testtoken")]
        public IActionResult testAPI(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Test Key");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return Ok(jwtToken);
        }
    }

}
