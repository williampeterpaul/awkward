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
    public class Context : DbContext
    {
        public Context()
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<User> Users { get; set; }

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Context>();

                context.Database.EnsureCreated();

                if (context.Entities.Any())
                {
                    return;
                }

                for (int i = 1; i < 100; i++)
                {
                    var entity = new Entity
                    {
                        Id = i,
                        Title = "Test " + i,
                        Content = "Content",
                        Grade = (Grade)new Random().Next(0, 2).TryParseDefault<Grade>(),
                        Category = (Category)new Random().Next(0, 4).TryParseDefault<Category>(),
                        Medium = (Medium)new Random().Next(0, 4).TryParseDefault<Medium>(),
                    };

                    var user = new User
                    {
                        Id = i,
                        Name = "Test Name " + i,
                        Alias = "Test Alias " + i,
                        Password = "Password",
                    };

                    user.Content.Add(entity);

                    context.Entities.Add(entity);
                    context.Users.Add(user);

                    context.SaveChanges();
                }
            }
        }
    }
}