using Core.UnitTests.Common;
using Demo.Core.Users.Commands;
using Demo.Domain.Entities;
using Demo.Infrastructure.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Core.UnitTests.Demo.Commands
{
    [Collection("CommandCollection")]
    public class AddUserTests
    {
        private DemoDbContext DbContext { get; set; }

        public AddUserTests(CommandTestFixtures fixture)
        {
            DbContext = fixture.Context;
        }

        [Fact]
        public async Task AddValidUserTest()
        {
            var requestHandler = new UserRequestHandler(DbContext);

            var userManager = new UserManager(new UserRequest
            {
                FirstName = "Jerry",
                LastName = "Louis"
            });

            var result = await requestHandler.Handle(userManager, CancellationToken.None);

            result.ShouldBeOfType<User>();
            result.FirstName.ShouldBe("Jerry");
            result.LastName.ShouldBe("Louis");
        }
    }
}
