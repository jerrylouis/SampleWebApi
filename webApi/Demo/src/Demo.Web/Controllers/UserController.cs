using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core.Users.Commands;
using Demo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Adds the given user details to the user table
        /// </summary>
        /// <param name="user">User request to be processed</param>
        /// <returns>Returns the User object as response.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<User>> AddUserDetailsAsync(UserRequest user)
        {
            var result = await Mediator.Send(new UserManager(user));
            return Ok(result);
        }
    }
}
