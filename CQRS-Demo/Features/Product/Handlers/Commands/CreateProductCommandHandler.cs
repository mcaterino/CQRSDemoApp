using CQRS_Demo.Contracts;
using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Features.Product.Requests.Commands;
using MediatR;

namespace CQRS_Demo.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int> {

        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository) {

            _repository = repository;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken) {

            var product = new ProductDTO();
            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.BuyingPrice = command.BuyingPrice;
            product.Rate = command.Rate;
            product.Description = command.Description;
            await _repository.Add(product);
            return product.Id;
        }
    }
}
