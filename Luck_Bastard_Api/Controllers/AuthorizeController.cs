using Data_Access.Commands;
using Data_Access.Features.Requestes;
using Data_Access.Features.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;

namespace Luck_Bastard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticateResponse>> AuthenticateAsync(AuthenticateRequest model)
        {
            var Query = new AuthorizationCommand
            {
                authenticateRequest = model
            };
            return await _mediator.Send(Query);
        }
    }
}
