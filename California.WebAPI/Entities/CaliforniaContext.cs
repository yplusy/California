using Microsoft.EntityFrameworkCore;

namespace California.WebAPI.Entities
{
    public class CaliforniaContext : DbContext
    {
        public CaliforniaContext() { }
        public CaliforniaContext(DbContextOptions<CaliforniaContext> options) : base(options) { }

        public DbSet<UserInfoEntity> User { get; set; } = null!;
    }
}
