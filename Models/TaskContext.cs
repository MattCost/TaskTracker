using Microsoft.EntityFrameworkCore;

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
        

    }
}
