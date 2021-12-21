using System;
using CollegeNetworkBackend1.Helpers;
using CollegeNetworkBackend1.Lib.Data;
using CollegeNetworkBackend1.Lib.Data.Data_Transfer_Objects;
using CollegeNetworkBackend1.Lib.Logic.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeNetworkBackend1.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService) {
            _repository = repository;   
            _jwtService = jwtService;
        }
        
        [HttpPost("register")]
        public IActionResult register(RegisterDto dto) {
            var user = new User {
                firstName = dto.firstName,
                lastName = dto.lastName,
                email = dto.email,
                password = BCrypt.Net.BCrypt.HashPassword(dto.password) 
            };
            return Created("success", _repository.create(user));
        }

        [HttpPost("login")]
        public IActionResult login(LoginDto dto) {
            var user = _repository.getByEmail(dto.email);

            if (user == null) 
                return BadRequest(new { message = "Invalid credentials" });
            
            if (!BCrypt.Net.BCrypt.Verify(dto.password, user.password)) 
                return BadRequest(new { message = "Invalid credentials" });
            

            var jwt = _jwtService.generate(user.id);
            
            Response.Cookies.Append("jwt", jwt, new CookieOptions {
                HttpOnly = true
            });
            
            return Ok(new { user });
        }

        [HttpGet("user")]
        public IActionResult user() {
            try {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _repository.getById(userId);

                return Ok(user);
            }
            catch (Exception _) {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult logout() {
            Response.Cookies.Delete("jwt");

            return Ok(new {
                message = "success"
            });
        }
    }
}