using Demo.Common;
using Demo.Domain.Entities;
using Demo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UnitTests.Common
{
    public class DemoDbContextFactory
    {
        public static DateTime dateTime;
        public static Mock<IDateTime> dateTimeMock;

        public static DemoDbContext Create()
        {
            dateTime = new DateTime(2050, 1, 1);
            dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var options = new DbContextOptionsBuilder<DemoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DemoDbContext(options, dateTimeMock.Object);

            context.Database.EnsureCreated();

            context.Users.AddRange(new[] {
                new User { FirstName = "Jerry", LastName = "Louis", CreatedDate = DateTime.Now },
                new User { FirstName = "Jack", LastName = "Reacher", CreatedDate = DateTime.Now },
                new User { FirstName = "Bill", LastName = "Murray", CreatedDate = DateTime.Now }
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DemoDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
