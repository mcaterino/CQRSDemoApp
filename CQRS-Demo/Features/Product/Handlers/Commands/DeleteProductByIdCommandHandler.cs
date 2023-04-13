using AutoMapper;
using CQRS_Demo.Contracts;
using CQRS_Demo.Features.Product.Requests.Commands;
using MediatR;

namespace CQRS_Demo.Features.Product.Handlers.Commands {
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int> {

        private readonly IProductRepository _repository;

        public DeleteProductByIdCommandHandler(IProductRepository repository) {
            
            _repository = repository;
        }

        public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken) {

            var product = _repository.Get(request.Id);
            if (product == null) return default;
            
            await _repository.Delete(request.Id);
            return product.Id;
        }
    }
}
