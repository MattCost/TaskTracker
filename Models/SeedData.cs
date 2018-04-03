using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TaskApp2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaskContext>>()))
            {
                // Look for any movies.
                if (context.Task.Any())
                {
                    return;   // DB has been seeded
                }

                context.Task.AddRange(
                     new Task
                     {
                         Name = "First Task1",
                         Desc = "This is the first task in our test system",
                         Complete = false
                     },
                     new Task
                     {
                         Name = "Second Task",
                         Desc = "This is the next task in our test system",
                         Complete = false
                     },
                     new Task
                     {
                         Name = "Tres Task",
                         Desc = "And This is the third task in our test system",
                         Complete = false
                     },
                     new Task
                     {
                         Name = "Fourth",
                         Desc = "Fourth task in our test system",
                         Complete = false
                     }                                                   

                );
                context.SaveChanges();
            }
        }
    }
}