using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Cors;
using MediatR;
using Data_Access.Models;
using Data_Access.Commands;
using Data_Access.Helpers;
using Data_Access.Response;
using Data_Access.Queries;

namespace Luck_Bastard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class HistoriesController : ControllerBase
    {
        public HistoriesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; set; }


        [Authorize]
        // GET: api/Histories
        [HttpGet("GamehistorywithCreater")]
        public async Task<IEnumerable<ChargeHistory>> GamehistorywithCreater()
        {
          

            return await Mediator.Send(new GameHistoryWithCreaterQuery(GUsername.GetUsername(HttpContext) ));

        }
        [Authorize]
        [HttpGet("GamehistorywithUsername")]
        public async Task<IEnumerable<ChargeHistory>> GamehistorywithUsername(string username)
        {
           

            return await Mediator.Send(new GameHistoryWithUsernameQuery(username));
        }
        [Authorize]
        [HttpGet("TransactionsGroupe")]
        public async Task<IEnumerable<TransactionsGroupRespone>> TransactionsGroupe()
        {
     

            return await Mediator.Send(new TransactionsGroupeQuery( GUsername.GetUsername(HttpContext)));

        }

        [Authorize]
        [HttpGet("LoginHistoryWithcreater")]
        public async Task<IEnumerable<LoginHistory>> LoginHistoryWithcreater()
        {
            return await Mediator.Send(new LoginHistoryWithCreaterQuery(GUsername.GetUsername(HttpContext)));
        }

        [Authorize]
        [HttpGet("LoginHistoryWithUsername")]
        public async Task<IEnumerable<LoginHistory>> LoginHistoryWithUsername(string username)
        {
            LoginHistoryWithUsernameQuery d;
            if (string.IsNullOrEmpty(username)) d = new LoginHistoryWithUsernameQuery(GUsername.GetUsername(HttpContext));
            else d = new LoginHistoryWithUsernameQuery(username);

            return await Mediator.Send(d);
        }
       
        [Authorize]
        [HttpGet("chargeHistoryRemoveOFoneuser")]
        public async Task<string> ChargeHistoryRemoveOFoneuser(string username)
        {
            ChargeHistoryRemoveOFoneuserQuery d;
            if (string.IsNullOrEmpty(username)) d = new ChargeHistoryRemoveOFoneuserQuery(GUsername.GetUsername(HttpContext));
            else d = new ChargeHistoryRemoveOFoneuserQuery(username);

            return await Mediator.Send(d);
        }

        [Authorize]
        [HttpGet("chargeHistoryRemoveOFonecreater")]
        public async Task<string> ChargeHistoryRemoveOFonecreater()
        {
     
            return await Mediator.Send(new ChargeHistoryRemoveOfCreaterQuery(GUsername.GetUsername(HttpContext)));
        }
    }
}
