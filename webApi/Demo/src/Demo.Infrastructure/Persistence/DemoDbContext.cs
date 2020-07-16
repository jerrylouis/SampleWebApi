using Demo.Common;
using Demo.Core.Interfaces;
using Demo.Domain.Common;
using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Persistence
{
    /// <summary>
    /// Demo DbContext for storing the user entity
    /// </summary>
    public class DemoDbContext : DbContext, IDemoDbContext
    {
        private readonly IDateTime dateTime;

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            :base(options)
        { 
        }

        public DbSet<User> Users { get; set; }

        Task<int> IDemoDbContext.SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                var loggedTime = dateTime == null ? DateTime.Now : dateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = loggedTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = loggedTime;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
