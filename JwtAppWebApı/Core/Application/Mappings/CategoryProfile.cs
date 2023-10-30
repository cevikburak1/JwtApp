using AutoMapper;
using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Domain;

namespace JwtAppWebApı.Core.Application.Mappings
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
