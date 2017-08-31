using Microsoft.EntityFrameworkCore;
using TaskManagerSM.Entities;

namespace TaskManagerSM.Db
{
    public class TasksContext : DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsInTask> TagsInTasks { get; set; }
    }
}