using Data_Access.Commands;
using Data_Access.Helpers;
using Data_Access.Queries;
using Data_Access.Requestes;
using Data_Access.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Luck_Bastard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargingController : ControllerBase
    {
  
        private readonly IMediator _mediator;
        public ChargingController( IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("InModelOpen")]
        public async Task<TimeCheckRespone> InModelOpen(string username)
        {

            var Query = new OpenBInModelQuery
            {
                Username = username
            };
            return await _mediator.Send(Query);
        }

        [Authorize]
        [HttpGet("OutModelOpen")]
        public async Task<OutModelRespone> OutModelOpen(string username)
        {

            var Query = new OpenBOutModelQuery
            {
                Username = username
            };
            return await _mediator.Send(Query);
        }

        [Authorize]
        [HttpPost("ChargeIn")]
        public async Task<string> BalanceInSellersave(BalanceInOutRequeste model)
        {
    
            var Query = new ChargeInCommand()
            {
                Username =  GUsername.GetUsername(HttpContext),
                inOutRequeste = model
            };
            return await _mediator.Send(Query);
        }

        [Authorize]
        [HttpPost("ChargeOut")]
        public async Task<string> ChargeOut(BalanceInOutRequeste model)
        {
         
            var Query = new ChargeOutCommand()
            {
                inOutRequeste = model
            };
            return await _mediator.Send(Query);
        }

        [Authorize]
        [HttpPost("ChargeAllOut")]
        public async Task<string> ChargeAllOut(BalanceInOutRequeste model)
        {
     
            var Query = new ChargeAllOutCommand()
            {
                inOutRequeste = model
            };
            return await _mediator.Send(Query);
        }


    }
}
