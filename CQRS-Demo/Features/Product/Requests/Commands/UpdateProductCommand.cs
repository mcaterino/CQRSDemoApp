using CQRS_Demo.DTOs.Product;
using MediatR;

namespace CQRS_Demo.Features.Product.Requests.Commands {
    public class UpdateProductCommand : IRequest<int> {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
    }
}
