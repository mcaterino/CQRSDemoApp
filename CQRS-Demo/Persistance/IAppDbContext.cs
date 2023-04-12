using CQRS_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Persistance {
    public interface IAppDbContext {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}