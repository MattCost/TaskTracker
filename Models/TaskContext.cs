using Microsoft.EntityFrameworkCore;
using System;

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

        public DateTime TaskTemplateUpdate;
        public DateTime TaskListUpdate;

         //https://benjii.me/2014/03/track-created-and-modified-fields-automatically-with-entity-framework-code-first/

    }
}
