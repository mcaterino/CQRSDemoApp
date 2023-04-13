using MediatR;

namespace CQRS_Demo.Features.Product.Requests.Commands
{
    public class CreateProductCommand : IRequest<int>
    {

        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string? ConfidentialData { get; set; }

    }
}
