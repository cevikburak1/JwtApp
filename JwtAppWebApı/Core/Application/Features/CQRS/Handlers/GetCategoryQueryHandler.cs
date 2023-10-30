using AutoMapper;
using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper  mapper;
        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
           var result = await this.repository.GetByFilterAsync(x => x.Id == request.Id);

            return this.mapper.Map<CategoryListDto>(result);
        }
    }
}
