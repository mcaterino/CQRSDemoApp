using AutoMapper;
using CQRS_Demo.Contracts;
using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Features.Product.Requests.Queries;
using CQRS_Demo.Models;
using CQRS_Demo.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Features.Product.Handlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) {

            var productList = await _repository.GetAll();
            if (productList is null) {

                return null;
            }
            return _mapper.Map<IEnumerable<ProductDTO>>(productList);
        }
    }
}
