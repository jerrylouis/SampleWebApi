using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Persistence
{
    public class DemoDbContextFactory: IDesignTimeDbContextFactory<DemoDbContext>
    {
        public DemoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DemoDbContext>();
            return new DemoDbContext(optionsBuilder.Options);
        }
    }
}
