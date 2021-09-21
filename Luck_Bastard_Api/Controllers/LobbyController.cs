
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Data_Access.Helpers;
using System.Threading.Tasks;
using MediatR;
using Data_Access.Queries;
using Data_Access.Response;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class LobbyController : ControllerBase
    {
        private readonly IMediator mediator;

        public LobbyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpGet("LobbyHeaderUserI")]

        public async Task<LobbyHeaderUserRespone> LobbyHeaderUserResponeI()
        {
            return await mediator.Send(new LobbyHeaderUserDetailsQuery(GUsername.GetUsername(HttpContext)));
        }
        [Authorize]
        [HttpGet("LobbyHeaderJackpotsD")]

        public async Task<LobbyHeaderJackpotsRespone> LobbyHeaderJackpotsD()
        {
            return await mediator.Send(new LobbyHeaderJackpotsDetailsQuery(GUsername.GetUsername(HttpContext)));


        }
    }
}