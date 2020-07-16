using Demo.Common;
using Demo.Domain.Entities;
using Demo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.IntegrationTests
{
    public class DemoDbContextTests
    {
        private readonly DemoDbContext dbContext;
        private readonly DateTime dateTime;
        private readonly Mock<IDateTime> dateTimeMock;

        public DemoDbContextTests()
        {
            dateTime = new DateTime(2050, 1, 1);
            dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var options = new DbContextOptionsBuilder<DemoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            dbContext = new DemoDbContext(options, dateTimeMock.Object);

            var user = new User
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "Reacher",
                CreatedDate = dateTime,
            };

            dbContext.Users.Add(user);
            dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task SaveNewUserDetails()
        {
            var user = new User
            {
                Id = 100,
                FirstName = "James",
                LastName = "Bond",
                CreatedDate = dateTime,
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            user.FirstName.ShouldBe("James");
            user.CreatedDate.ShouldBe(dateTime);
        }

        [Fact]
        public async Task GetUserDetails()
        {
            var user = await dbContext.Users.FindAsync(1);

            user.ShouldBeOfType<User>();
            user.FirstName.ShouldBe("Jack");
            user.LastName.ShouldBe("Reacher");
            user.CreatedDate.ShouldBe(dateTime);
        }
    }
}
