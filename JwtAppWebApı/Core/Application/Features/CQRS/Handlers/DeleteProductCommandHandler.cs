using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var Deleteresult =await this.repository.GetByIdAsync(request.Id);
            if (Deleteresult != null)
            {
                await this.repository.RemoveAsync(Deleteresult);
            }
            return Unit.Value;
        }
    }
}
