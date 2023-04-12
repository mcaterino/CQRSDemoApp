using AutoMapper;
using CQRS_Demo.DTOs.Product;
using CQRS_Demo.Models;

namespace CQRS_Demo.Profiles {
    public class MappingProfile : Profile {

        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }



    }
}
