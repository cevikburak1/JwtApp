using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAppWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await this.mediator.Send(new GetCategoriesQueryRequest());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.mediator.Send(new GetCategoryQueryRequest(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
