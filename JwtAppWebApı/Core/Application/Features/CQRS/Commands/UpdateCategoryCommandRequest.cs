using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Defination { get; set; }
    }
}
