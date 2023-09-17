using StarterKit.Application.Features.Guitars.Queries.GetAllGuitars;
using StarterKit.Application.Features.Guitars.Queries.GetGuitarById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarterKitAPI.Attributes;

namespace StarterKitAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GuitarController : BaseApiController
    {

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllGuitarsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllGuitarsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGuitarByIdQuery { Id = id }));
        }
    }
}
