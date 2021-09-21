using Data_Access.DBContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Data_Access.Commands
{
public    class DeleteUserCommand : IRequest<string>
    {
        public DeleteUserCommand(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand,string>
    {
        private MyDBContext Context { get; set; }
        public DeleteUserCommandHandler(MyDBContext context)
        {
            Context = context;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Context.Users.Remove( Context.Users.FirstOrDefault(x=>x.Username==request.Username));
        var result=    await Context.SaveChangesAsync();

            if (result > 0) return "User Deleted";
            else return "Error happend";
        }
    }
}
