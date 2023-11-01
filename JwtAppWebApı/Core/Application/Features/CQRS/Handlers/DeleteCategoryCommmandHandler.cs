using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommmandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public DeleteCategoryCommmandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var Deleteresult = await this.repository.GetByIdAsync(request.Id);
            if (Deleteresult != null)
            {
                await this.repository.RemoveAsync(Deleteresult);
            }
            return Unit.Value;
        }
    }
}
