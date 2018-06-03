using awkward.api.Extensions;
using awkward.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static awkward.api.Models.Static.Enumerations;

namespace awkward.api.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ApplicationContent> Contents { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                if (context.Contents.Any())
                {
                    return;
                }

                for (int i = 1; i < 100; i++)
                {
                    var entity = new ApplicationContent
                    {
                        Id = i,
                        Title = "Test " + i,
                        Content = "Content",
                        Grade = (Grade)new Random().Next(0, 2).TryParseDefault<Grade>(),
                        Category = (Category)new Random().Next(0, 4).TryParseDefault<Category>(),
                        Medium = (Medium)new Random().Next(0, 4).TryParseDefault<Medium>(),
                    };

                    context.Contents.Add(entity);

                    context.SaveChanges();
                }
            }
        }
    }
}