using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenCart.DatabaseSpecific;
using OpenCart.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
namespace OpenCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataAccessAdapter _dataAccessAdapter;
        public UsersController(DataAccessAdapter dataAccessAdapter)
        {
            _dataAccessAdapter = dataAccessAdapter;
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] UserRequest req)
        {
            if (req == null)
            {
                return BadRequest("User data is null");
            }
            try
            {
                if(req.Password == null || req.Password.Length < 8)
                {
                    return BadRequest("Password must be at least 8 characters long");
                }
                req.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
                var user = new UserEntity
                {
                    Firstname = req.Firstname,
                    Lastname = req.Lastname,
                    Username = req.Username,
                    Password = req.Password,
                    IsActive = req.IsActive
                };
                _dataAccessAdapter.SaveEntity(user);
                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }

    public class UserRequest
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserResponse
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public bool IsActive { get; set; }
    }

}
