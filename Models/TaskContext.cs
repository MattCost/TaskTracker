using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace TaskApp2.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext (DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<TaskApp2.Models.Task> Task { get; set; }
        public DbSet<TaskApp2.Models.TaskTemplate> TaskTemplate {get;set;}
        public DbSet<TaskApp2.Models.TaskInstance> TaskList {get; set;}

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

    /*    var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
            ? HttpContext.Current.User.Identity.Name
            : "Anonymous";
        */
        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                //((BaseEntity)entity.Entity).UserCreated = currentUsername;
            }

            ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
            //((BaseEntity)entity.Entity).UserModified = currentUsername;
        }
    }
         //https://benjii.me/2014/03/track-created-and-modified-fields-automatically-with-entity-framework-code-first/

    }
}
