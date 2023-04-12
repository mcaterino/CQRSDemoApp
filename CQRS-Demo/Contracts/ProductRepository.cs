using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Models;
using CQRS_Demo.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CQRS_Demo.Contracts {
    public class ProductRepository : IProductRepository {

        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) {

            _context = context;
        }

        public async Task<Product> Add(Product entity) {
            
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id) {
            
            var entity = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            EntityEntry entityEntry = _context.Entry<Product>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id) {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) {
                return null;
            }
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAll() {

            var allProducts = await _context.Products.ToListAsync();
            return allProducts;
        }

        public async Task Update(Product entity) {

            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
