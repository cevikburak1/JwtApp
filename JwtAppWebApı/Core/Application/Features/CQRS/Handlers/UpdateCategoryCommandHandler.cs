using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
        var entity = await this.repository.GetByIdAsync(request.Id);
            if(entity != null)
            {
                entity.Defination = request.Defination;
               await this.repository.UpdateAsync(entity);
            }
            return Unit.Value;
        }
    }
}
