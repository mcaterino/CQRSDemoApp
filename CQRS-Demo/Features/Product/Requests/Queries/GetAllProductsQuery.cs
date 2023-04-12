using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Models;
using MediatR;

namespace CQRS_Demo.Features.Product.Requests.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
