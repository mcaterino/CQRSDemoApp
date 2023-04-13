using AutoMapper;
using CQRS_Demo.Contracts;
using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Features.Product.Requests.Commands;
using MediatR;

namespace CQRS_Demo.Features.Product.Handlers.Commands {
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int> {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper) {
            
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken) {

            var product = await _repository.Get(request.Id);

            if (product is null) {

                return default;
            }
            else {
                product.Barcode = request.Barcode;
                product.Name = request.Name;
                product.BuyingPrice = request.BuyingPrice;
                product.Rate = request.Rate;
                product.Description = request.Description;
                await _repository.Update(product);
                return product.Id;
            }

        }
    }
}
