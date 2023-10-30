using JwtAppWebApı.Core.Application.Features.CQRS.Commands;
using JwtAppWebApı.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAppWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await this.mediator.Send(new GetAllProductsQueryRequest());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.mediator.Send(new GetProductQueryRequest(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new DeleteProductCommandRequest(id));     
            return NoContent();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
         await this.mediator.Send(request);
            return Created("",request);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

    }
}
