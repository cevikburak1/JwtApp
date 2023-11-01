using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCommandCategoryRequest>
    {
        private readonly IRepository<Category> repostitory;

        public CreateCategoryCommandHandler(IRepository<Category> repostitory)
        {
            this.repostitory = repostitory;
        }

        public async Task<Unit> Handle(CreateCommandCategoryRequest request, CancellationToken cancellationToken)
        {
            await this.repostitory.CreateAsync(new Category
            {
                Defination = request.Defination,

            });
            return Unit.Value;
        }
    }
}
