using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarterKitAPI.Attributes;

namespace StarterKitAPI.Controllers
{
    [ApiKey]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
