using AutoMapper;
using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
           var result =  await this.repository.GetAllAsnyc();

            return this.mapper.Map<List<CategoryListDto>>(result);
        }
    }
}
