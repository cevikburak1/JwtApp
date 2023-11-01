using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Application.Features.CQRS.Handlers;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest :IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!; //null olamazzz
    }
}
