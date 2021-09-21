using Data_Access.Communication;
using Data_Access.Helpers;
using Data_Access.Commands;
using Data_Access.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data_Access.Features.Requestes;

namespace Luck_Bastard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RockySpinController : ControllerBase
    {

        private readonly IMediator _mediator;
        public RockySpinController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [Authorize]
        [HttpPost("Spin")]
        public async Task<Response<ValueSpinRespone>> Spin(RockySpinRequest rockySpinRequest)
        {

            var f = new RockySpinCommand
            {
                Username = GUsername.GetUsername(HttpContext),
                RockySpinRequest = rockySpinRequest
            };
            return await _mediator.Send(f);
        }
        [Authorize]
        [HttpPost("RockyfreeSpinning")]
        public async Task<Response<ValueSpinRespone>> RockyfreeSpinning(RockySpinRequest rockySpinRequest)
        {
 
            var f = new RockyfreeSpinningCommand
            {
                Username =  GUsername.GetUsername(HttpContext),
                RockySpinRequest = rockySpinRequest
            };
            return await _mediator.Send(f);
        }
        [Authorize]
        [HttpPost("TestBonus")]
        public async Task<Response<ValueSpinRespone>> TestBonus(RockySpinRequest rockySpinRequest)
        {
      
            var f = new TestBonusCommand
            {
                Username =  GUsername.GetUsername(HttpContext),
                RockySpinRequest = rockySpinRequest
            };
            return await _mediator.Send(f);
        }
        [Authorize]
        [HttpPost("TestWildBonus")]
        public async Task<Response<ValueSpinRespone>> TestWildBonus(RockySpinRequest rockySpinRequest)
        {
      
            var f = new TestWildBonusCommand
            {
                Username =  GUsername.GetUsername(HttpContext),
                RockySpinRequest = rockySpinRequest
            };
            return await _mediator.Send(f);
        }
        [Authorize]
        [HttpPost("TestWild")]
        public async Task<Response<ValueSpinRespone>> TestWild(RockySpinRequest rockySpinRequest)
        {
  
            var f = new TestWildCommand
            {
                Username = GUsername.GetUsername(HttpContext),
                RockySpinRequest = rockySpinRequest
            };
            return await _mediator.Send(f);
        }
        
       [Authorize]
        [HttpGet("CrackRock")]
        public async Task<int?> CrackRock()
        {
        
            var f = new CrackRockCommand
            {
                Username =  GUsername.GetUsername(HttpContext),
                
            };
            return await _mediator.Send(f);
        }
    }
}
