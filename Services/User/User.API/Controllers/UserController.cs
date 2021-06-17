using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User.API.Services.Abstracts;
using User.Model;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Get a user by userId
        /// </summary>
        /// <returns>Returns a user model object</returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserModel), 200)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Not Found
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> GetUserByUserIdAsync(Guid userId)
        {
            var result = await _userService.GetUserByUserIdAsync(userId);

            return Ok(result);
        }

        /// <summary>
        /// insert a user with Username = userName
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 200)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> CreateUserAsync(string userName)
        {
            await _userService.CreateUserAsync(userName);

            return Ok();
        }
    }
}
