using AutoMapper;
using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Domain;

namespace JwtAppWebApı.Core.Application.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
