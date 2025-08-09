using System.Threading.Tasks;
using CS004_SwaggerUI.Entities;
using CS004_SwaggerUI.EventHandler;
using CS004_SwaggerUI.Models;
using CS004_SwaggerUI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CS004_SwaggerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public UserController(
            IUserRepository userRepository,
            IEventDispatcher eventDispatcher
            )
        {
            _userRepository = userRepository;
            _eventDispatcher = eventDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User ID is required");
            }

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID '{id}' not found");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User ID is required");
            }

            if (request == null)
            {
                return BadRequest("User data is required");
            }

            // Check if user exists
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID '{id}' not found");
            }

            // Check if username is taken by another user
            if (!string.IsNullOrWhiteSpace(request.Username) && request.Username != existingUser.Username)
            {
                var usernameExists = await _userRepository.UsernameExistsAsync(request.Username);
                if (usernameExists)
                {
                    return BadRequest("Username is already taken");
                }
            }

            // Check if email is taken by another user
            if (!string.IsNullOrWhiteSpace(request.Email) && request.Email != existingUser.Email)
            {
                var emailExists = await _userRepository.EmailExistsAsync(request.Email);
                if (emailExists)
                {
                    return BadRequest("Email is already taken");
                }
            }

            // Update user properties
            existingUser.Username = request.Username ?? existingUser.Username;
            existingUser.Email = request.Email ?? existingUser.Email;
            existingUser.PasswordHash = request.PasswordHash ?? existingUser.PasswordHash;

            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
            return Ok(updatedUser);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(string id, [FromBody] UpdateUserStatusRequest request)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User ID is required");
            }

            if (request == null)
            {
                return BadRequest("Status data is required");
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID '{id}' not found");
            }

            // existingUser.Status = request.Status;
            existingUser.SetStatus(request.Status);
            _eventDispatcher.Dispatch(existingUser.DomainEvents);
            existingUser.ClearDomainEvents();
            
            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
            
            return Ok(new { 
                Message = $"User status updated to {request.Status}", 
                User = updatedUser 
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User ID is required");
            }

            var userExists = await _userRepository.UserExistsAsync(id);
            if (!userExists)
            {
                return NotFound($"User with ID '{id}' not found");
            }

            var deleted = await _userRepository.DeleteUserAsync(id);
            if (deleted)
            {
                return Ok(new { Message = "User deleted successfully" });
            }

            return StatusCode(500, "Failed to delete user");
        }
    }    
}
