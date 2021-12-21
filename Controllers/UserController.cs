using CollegeNetworkBackend1.Lib.Data;
using CollegeNetworkBackend1.Lib.Data.Data_Transfer_Objects;
using CollegeNetworkBackend1.Lib.Logic.User;
using Microsoft.AspNetCore.Mvc;

namespace CollegeNetworkBackend1.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) {
            _repository = repository;
        }
        
        [HttpPut("update_user")]
        public IActionResult updateUser(UserDto dto) {
            var updatedUser = new User {
                id = dto.id,
                firstName = dto.firstName,
                lastName = dto.lastName,
                email = dto.email,
                phoneNumber = dto.phoneNumber,
                dateOfBirth = dto.dateOfBirth,
                gender = dto.gender,
                password = BCrypt.Net.BCrypt.HashPassword(dto.password)
            };
            _repository.update(updatedUser);
            return Ok("Updated succesfully");
        }

        [HttpGet("get_all_users")]
        public IActionResult getAllUsers() {
            var users = _repository.getAll();
            return Ok(users);
        }
    }
}