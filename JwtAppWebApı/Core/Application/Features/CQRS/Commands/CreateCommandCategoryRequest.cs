using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Commands
{
    public class CreateCommandCategoryRequest : IRequest
    {
        public string? Defination { get; set; }
    }
}
