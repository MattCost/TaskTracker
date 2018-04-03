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
    }
}
