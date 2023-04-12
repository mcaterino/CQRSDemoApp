using AutoMapper;
using CQRS_Demo.Contracts;
using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Features.Product.Requests.Queries;
using CQRS_Demo.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Features.Product.Handlers.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO> {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper) {
            
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {

            var product = await _repository.Get(request.Id);
            if (product == null) return null;
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
