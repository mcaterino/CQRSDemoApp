using MediatR;

namespace CQRS_Demo.Features.Product.Requests.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; } 
    }
}
