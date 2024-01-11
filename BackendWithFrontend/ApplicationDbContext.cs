
using Microsoft.EntityFrameworkCore;

namespace BackendWithFrontend
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
