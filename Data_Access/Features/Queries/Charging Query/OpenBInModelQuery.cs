using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data_Access.DBContext;
using Data_Access.Response;
using MediatR;


namespace Data_Access.Queries
{
  public  class OpenBInModelQuery:IRequest<TimeCheckRespone>
    {
        public string Username { get; set; }
    }
    public class OpenBInModelQueryHandler : IRequestHandler<OpenBInModelQuery, TimeCheckRespone>
    {
        public MyDBContext Context { get; }
        public OpenBInModelQueryHandler(MyDBContext context)
        {
            Context = context;
        }

      

        public Task<TimeCheckRespone> Handle(OpenBInModelQuery request, CancellationToken cancellationToken)
        {
            var user=Context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (user.Balance>= 1&&user.UserType!=Enum.UserType.Player) return Task.FromResult( new TimeCheckRespone { ErrorMessage = "Player have enough balance" });
            return Task.FromResult(TimeCheckRespone.CheckHouer(request.Username, Context));

        }
    }
}
