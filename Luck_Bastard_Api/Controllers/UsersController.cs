using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Data_Access.Features.Requestes;
using Data_Access.Commands;
using Data_Access.Queries;
using Data_Access.Features.Response;
using Data_Access.Response;
using Data_Access.Requestes;
using Data_Access.Helpers;
using Data_Access.Models;

namespace Luck_Bastard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        // GET: api/Users
        [Authorize]
        [HttpGet("AllUsers")]
        public async Task<IEnumerable<UserInformationResponse>> GetUsers()
        {

            return await _mediator.Send(new GetAllUsersQuery());
        }
        [Authorize]
        [HttpGet("AllUsersWithCreater")]
        public async Task<IEnumerable<UserInformationResponse>> AllUsersWithCreater()
        {

            return await _mediator.Send(new GetAllUserWCreatersQuery(GUsername.GetUsername(HttpContext)));
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost("AddUser")]
        public async Task<ActionResult<string>> AddUser(AddUserRequest addUserRequest)
        {


             addUserRequest.Creater = GUsername.GetUsername(HttpContext);
            return await _mediator.Send(new CreateUserCommand(addUserRequest));
        }
        [HttpPost("AddnewUser")]
        public async Task<ActionResult<string>> AddnewUser(AddUserRequest addUserRequest)
        {


      
            return await _mediator.Send(new CreateUserCommand(addUserRequest));
        }
        [Authorize]
        [HttpPost("UpdatePassword")]
        public async Task<string> ChangeMyPassword(SetNewPasswordRequest setNewPassword)
        {
         
            if (string.IsNullOrEmpty(setNewPassword.Username)) setNewPassword.Username = GUsername.GetUsername(HttpContext);
         
          
            return await _mediator.Send(new ChangePasswordCommand(setNewPassword));
        }
        // Header Panel Information to display
        [Authorize]
        [HttpGet("HeaderPanel")]
        public async Task<HeaderRespone> HeaderPlanel()
        {
            //if (User.Identity.Name == null)eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InN0cmluZyIsIm5iZiI6MTYwOTA5NzI1MiwiZXhwIjoxNjA5NzAyMDUyLCJpYXQiOjE2MDkwOTcyNTJ9.R98_6CS51o0mU4onwoOaj5lSn1bl_uSjFT0i32RCkdo
            //    return null;
  
      
            return await _mediator.Send(new GetHeaderPanelQuery(GUsername.GetUsername(HttpContext)));

        }

        // DELETE: api/Users/5
        [Authorize]
        [HttpPost("deleteuser")]
        public async Task<string> DeleteTuser(string username)
        {

            return await _mediator.Send(new DeleteUserCommand(username));
        }
    }
}
