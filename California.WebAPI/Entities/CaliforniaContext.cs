using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Reflection.Metadata;

namespace California.WebAPI.Entities
{
    public class CaliforniaContext : DbContext
    {
        public CaliforniaContext(DbContextOptions<CaliforniaContext> options) : base(options) { }

        public DbSet<ExampleEntity> Example { get; set; } = null!;
        public DbSet<AccountEntity> Account { get; set; } = null!;
        public DbSet<BlogEntity> Blog { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogEntity>(e =>
            {
                // e.Property(t => t.BlogId).HasValueGenerator<GuidValueGenerator>(); // guid
                e.Property(t => t.CreateTime).HasDefaultValueSql("gen_random_uuid()"); 
                e.Property(t => t.CreateTime).HasDefaultValueSql("LOCALTIMESTAMP(0)"); // 数据库默认值
            });
        }
    }
}
