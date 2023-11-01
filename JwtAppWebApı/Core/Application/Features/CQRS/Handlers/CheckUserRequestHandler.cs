using JwtAppWebApı.Core.Application.Dto;
using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Core.Domain;
using MediatR;

namespace JwtAppWebApı.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest,CheckUserResponseDto>
    {

        private readonly IRepository<AppUser> userepository;
        private readonly IRepository<AppRole> rolerepository;
        public CheckUserRequestHandler(IRepository<AppUser> userepository, IRepository<AppRole> rolerepository)
        {
            this.userepository = userepository;
            this.rolerepository = rolerepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userepository.GetByFilterAsync(x=>x.UserName==request.UserName && x.Password==request.Password);

            if(user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                var role = await this.rolerepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Defination;
                dto.IsExist = true;
            }
            return dto;
        }
    }
}
