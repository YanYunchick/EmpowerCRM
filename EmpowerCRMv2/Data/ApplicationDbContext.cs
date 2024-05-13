using EmpowerCRMv2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpowerCRMv2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<OpportunityStage> OpportunityStages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OpportunityProduct> OpportunityProducts { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserTaskPriority> UserTaskPriorities { get; set; }
        public DbSet<UserTaskStatus> UserTaskStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add Identity related model configuration
            base.OnModelCreating(modelBuilder);

            // Your fluent modeling here
            modelBuilder
            .Entity<Opportunity>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Opportunities)
            .UsingEntity<OpportunityProduct>(
               j => j
                .HasOne(pt => pt.Product)
                .WithMany(t => t.OpportunityProducts)
                .HasForeignKey(pt => pt.ProductId),
               j => j
                .HasOne(pt => pt.Opportunity)
                .WithMany(p => p.OpportunityProducts)
                .HasForeignKey(pt => pt.OpportunityId),
               j =>
               {
                   j.Property(pt => pt.Quantity).HasDefaultValue(1);
                   j.HasKey(t => new { t.OpportunityId, t.ProductId });
                   j.ToTable("OpportunityProduct");
               });

        }
    }
}
