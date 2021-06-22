using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.API.Services.Abstracts;
using User.Model.RequestModels;
using User.Model.ResponseModels;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {   
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a user by userId
        /// </summary>
        /// <returns>Returns a user model object</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(UserModel), 200)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Not Found
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> GetUserByUserIdAsync(Guid userId)
        {
            try
            {
                var result = await _userService.GetUserByUserIdAsync(userId);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 201)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Not Found
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> CreateUserAsync([FromBody]AddUserModel addUserModel)
        {
            try
            {
                var result = await _userService.CreateUserAsync(addUserModel);

                return Ok(result);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
