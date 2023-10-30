using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateresult = await this.repository.GetByIdAsync(request.Id);
            if (updateresult != null)
            {
                updateresult.CategoryId = request.CategoryId;
                updateresult.Stock = request.Stock;
                updateresult.Price = request.Price;
                updateresult.Name = request.Name;
               await this.repository.UpdateAsync(updateresult);
            }

            return Unit.Value;
        }
    }
}
