using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest :IRequest<List<CategoryListDto>>
    {

    }
}
