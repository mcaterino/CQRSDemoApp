using CQRS_Demo.Common;

namespace CQRS_Demo.Models {
    public class Product : BaseDomainEntity {

        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string? ConfidentialData { get; set; }

    }
}
