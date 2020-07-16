using Demo.Domain.Entities;
using Demo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.IntergrationTests.Common
{
    public class SeedData
    {
        internal static void InitialiseDatabase(DemoDbContext context)
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "Reacher",
                CreatedDate = DateTime.Now,
            };

            context.Users.Add(user);
            context.SaveChangesAsync();
        }
    }
}
