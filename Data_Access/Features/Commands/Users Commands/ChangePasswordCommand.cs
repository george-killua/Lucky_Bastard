using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Data_Access.DBContext;
using Data_Access.Requestes;
using Data_Access.Services;

namespace Data_Access.Commands
{
    public class ChangePasswordCommand : IRequest<string>
    {
        
        public SetNewPasswordRequest SetNewPasswordRequest { get; set; }

        public ChangePasswordCommand(SetNewPasswordRequest setNewPasswordRequest)
        {
           SetNewPasswordRequest = setNewPasswordRequest;
        }
    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        private MyDBContext Context { get; set; }
        public ChangePasswordCommandHandler(MyDBContext context)
        {
            Context = context;
        }
        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.SetNewPasswordRequest.NewPassword.Equals(request.SetNewPasswordRequest.ConfirmPassword)) return "Not Matched New Password and confirm"; ;

            var user = Context.Users.FirstOrDefault(x => x.Username == request.SetNewPasswordRequest.Username);
            if (!string.IsNullOrEmpty(request.SetNewPasswordRequest.Oldpassword))
            {
                if (EncDec.Decrypt(user.Password).Equals(request.SetNewPasswordRequest.Oldpassword) == false)
                {
                    return "Not Matched old Password";
                }
            }
            user.Password = EncDec.Decrypt(request.SetNewPasswordRequest.NewPassword);
            Context.Users.Update(user);
            var result = await Context.SaveChangesAsync();

            if (result > 0) return "User Password Updated";
            else return "Error happend";
        }
    }

}
