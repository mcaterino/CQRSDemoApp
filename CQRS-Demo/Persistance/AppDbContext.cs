using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Persistance {
    public class AppDbContext : DbContext {

        public DbSet<ProductDTO> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        
    }
}
