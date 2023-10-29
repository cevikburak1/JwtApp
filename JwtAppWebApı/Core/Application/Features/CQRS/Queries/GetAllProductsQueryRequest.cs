using JwtAppWebApı.Core.Application.Dto;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest :IRequest<List<ProductListDto>>
    {

    }
}
