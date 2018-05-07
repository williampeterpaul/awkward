using awkward.api.Extensions;
using awkward.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static awkward.api.Models.Enumerations;

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

                for (int i = 1; i < 1000; i++)
                {
                    context.Entities.Add(new Entity
                    {
                        Id = i,
                        Title = "Test " + i,
                        Content = "Content",
                        Category = (Category) new Random().Next(0, 4).TryParseDefault<Category>(),
                        Medium = (Medium) new Random().Next(0, 4).TryParseDefault<Medium>(),
                        Grade = (Grade) new Random().Next(0, 2).TryParseDefault<Grade>(),
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
