using CQRS_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Persistance {
    public class AppDbContext : DbContext, IAppDbContext {

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public async Task<int> SaveChanges() {

            return await base.SaveChangesAsync();
        }
    }
}
