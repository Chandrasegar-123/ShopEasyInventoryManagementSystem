using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEasyIMS.DTOs;
using ShopEasyIMS.Services;

namespace ShopEasyIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // All endpoints require authentication
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        [Authorize(Roles = "Admin")] // Only Admin can access all users
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can access a specific user by ID
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin can create users
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.AddUserAsync(userDto);
            if (!result)
                return BadRequest(new { message = "Username already exists" });

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, userDto);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can update user roles
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] string newRole)
        {
            if (string.IsNullOrWhiteSpace(newRole))
                return BadRequest(new { message = "Role cannot be empty" });

            var result = await _userService.UpdateUserRoleAsync(id, newRole);
            if (!result)
                return NotFound(new { message = "User not found" });

            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete users
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound(new { message = "User not found" });

            return NoContent();
        }

        // GET: api/user/employees
        [HttpGet("employees")]
        [Authorize(Roles = "Admin")] // Only Admin can access employee users
        public async Task<IActionResult> GetEmployeeUsers()
        {
            var employees = await _userService.GetAllUsersAsync();
            var employeeUsers = employees.Where(u => u.Role == "Employee").ToList();

            return Ok(employeeUsers);
        }
    }
}
