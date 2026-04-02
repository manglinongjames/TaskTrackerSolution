using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Entities;

namespace TaskTracker.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        /// <summary>
        /// Configure db context options
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired(false);
                entity.Property(e => e.DueDate).IsRequired(false);
                entity.Property(e => e.Description).IsRequired(false);
                //entity.Property(e => e.Description).HasMaxLength(500);
                //entity.Property(e => e.Status).IsRequired();
                //entity.Property(e => e.CreatedAt).IsRequired();
                //entity.Property(e => e.UpdatedAt).IsRequired();
            });
        }
    }
}
