using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;

namespace ToDoApp.DataBaseRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TaskInfo> Tasks => Set<TaskInfo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskInfo>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Recurrence).HasConversion<string>();
                entity.HasData(
                    new TaskInfo
                    {
                        Id = 1,
                        TaskName = "Water plants",
                        TaskDescription = "Balcony plants",
                        Recurrence = RecurrenceType.Daily,
                        IsCompleted = false,
                        CreatedAt = new DateTime(2026, 10, 1, 9, 0, 0),
                        DueDate = new DateTime(2026, 10, 10, 9, 0, 0)
                    },
                    new TaskInfo
                    {
                        Id = 2,
                        TaskName = "Team sync",
                        TaskDescription = "Weekly status meeting",
                        Recurrence = RecurrenceType.Weekly,
                        IsCompleted = false,
                        CreatedAt = new DateTime(2026, 10, 1, 9, 0, 0),
                        DueDate = new DateTime(2026, 10, 12, 10, 0, 0)
                    }
                    );
            });
        }
    }
}