using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using JwtAppWebApı.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAppWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest reguest)
        {
            await this.mediator.Send(reguest);
            return Created("", reguest);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest reguest)
        {
            var dto = await this.mediator.Send(reguest);
            if (dto.IsExist)
            {
     
                return Created("", JwtTokenGenerator.GenereateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }
        }
       

    }
}
