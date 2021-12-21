using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeNetworkBackend1.Lib.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeNetworkBackend1.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AdminController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpDelete("delete_user/{id:int}")]
        public IActionResult deleteUser(int id) {
            var user = _repository.findById(id);

            if (user == null)
                return NotFound();

            _repository.delete(user);
            return Ok("User deleted succesfully");
        }
    }
}