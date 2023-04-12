using CQRS_Demo.DTOs.Common;
using CQRS_Demo.DTOs.Product;
using MediatR;

namespace CQRS_Demo.Features.Product.Requests.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO> {

        public int Id { get; set; }

    }
}
