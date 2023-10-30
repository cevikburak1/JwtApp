using JwtAppWebApı.Core.Application.Dto;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest :IRequest<CategoryListDto?>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;        
        }
    }
}
