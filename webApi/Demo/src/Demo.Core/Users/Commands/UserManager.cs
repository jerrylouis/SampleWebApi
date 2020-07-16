using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Domain.Entities;

namespace Demo.Core.Users.Commands
{
    public class UserManager : IRequest<User>
    {
        public UserRequest User { get; }

        public UserManager(UserRequest user)
        {
            User = user;
        }
    }
}
