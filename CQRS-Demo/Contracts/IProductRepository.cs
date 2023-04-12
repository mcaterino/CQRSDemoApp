using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Models;

namespace CQRS_Demo.Contracts {
    public interface IProductRepository : IGenericRepository<Product> {
    }
}
