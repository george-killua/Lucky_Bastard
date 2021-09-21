using Data_Access.DBContext;
using Data_Access.Features.Requestes;
using Data_Access.Models;
using Data_Access.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public AddUserRequest AddUserR { get; set; }

        public CreateUserCommand(AddUserRequest addUserR)
        {
            this.AddUserR = addUserR;
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private MyDBContext Context { get; set; }
        public CreateUserCommandHandler(MyDBContext context)
        { 
          Context = context;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = Context.Users.Where(x => x.Username == request.AddUserR.Username).FirstOrDefault();
            if (user!=null)
            {
                return  "already exists";
            }
            User newUser = new User
            {
                Username = request.AddUserR.Username,
                Password = EncDec.Encrypt(request.AddUserR.Password),
                UserType = request.AddUserR.Type,
                Creater = request.AddUserR.Creater
            };
             Context.Users.Add(newUser);
            var result=await Context.SaveChangesAsync();

           if(result>0) return "User Created";
           else return "User not Created";
        }
    }
}
