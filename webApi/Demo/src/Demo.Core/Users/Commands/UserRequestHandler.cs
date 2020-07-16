using Demo.Core.Interfaces;
using Demo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Users.Commands
{
    public class UserRequestHandler : IRequestHandler<UserManager, User>
    {
        private readonly IDemoDbContext dbContext;

        public UserRequestHandler(IDemoDbContext context)
        {
            dbContext = context;
        }
        public async Task<User> Handle(UserManager request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                CreatedDate = DateTime.Now
            };

            // Lets add this user to the user table
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
