using Demo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Core.UnitTests.Common
{
    public class CommandTestFixtures
    {
        public DemoDbContext Context { get; set; }

        public CommandTestFixtures()
        {
            Context = DemoDbContextFactory.Create();
        }

        public void Dispose()
        {
            DemoDbContextFactory.Destroy(Context);
        }

        [CollectionDefinition("CommandCollection")]
        public class CommandCollection : ICollectionFixture<CommandTestFixtures> { }
    }
}
