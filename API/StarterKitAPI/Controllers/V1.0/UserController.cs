using StarterKit.Application.Features.Users.Queries.GetAllUsers;
using StarterKit.Application.Features.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarterKit.Application.Features.UserPosts.Queries.GetUserPostById;
using StarterKitAPI.Attributes;

namespace StarterKitAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUsersParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllUsersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        // GET api/<controller>/5
        [HttpGet("userpost/{id}")]
        public async Task<IActionResult> GetUserPost(int id)
        {
            return Ok(await Mediator.Send(new GetUserPostByUserIdQuery { Id = id }));
        }
    }
}
