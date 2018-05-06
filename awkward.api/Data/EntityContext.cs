using awkward.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext()
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        public DbSet<Entity> Entities { get; set; }

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<EntityContext>();

                context.Database.EnsureCreated();

                if (context.Entities.Any())
                {
                    return;
                }

                context.Entities.AddRange(new Entity[] {
                    new Entity
                    {
                        Id = 1,
                        Name = "Test A",
                        Description = "Sentence describing test A",
                        Content = "Content",
                        CreationDate = DateTime.Now
                    },
                    new Entity
                    {
                        Id = 2,
                        Name = "Test B",
                        Description = "Sentence describing test B",
                        Content = "Content",
                        CreationDate = DateTime.Now
                    },
                    new Entity
                    {
                        Id = 3,
                        Name = "Test C",
                        Description = "Sentence describing test C",
                        Content = "Content",
                        CreationDate = DateTime.Now
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
