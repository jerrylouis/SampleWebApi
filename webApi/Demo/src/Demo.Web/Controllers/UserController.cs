using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core.Users.Commands;
using Demo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<User>> AddUserDetailsAsync(UserRequest user)
        {
            var result = await Mediator.Send(new UserManager(user));
            return Ok(result);
        }
    }
}
