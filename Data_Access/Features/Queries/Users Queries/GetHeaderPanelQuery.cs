using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data_Access.DBContext;
using Data_Access.Response;
using MediatR;
using System.Linq;
namespace Data_Access.Queries
{
    public class GetHeaderPanelQuery:IRequest<HeaderRespone>
    {
        public GetHeaderPanelQuery(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
    public class GetHeaderPanelQueryHandler : IRequestHandler<GetHeaderPanelQuery, HeaderRespone>
    {
        private MyDBContext Context { get; set; }

        public GetHeaderPanelQueryHandler(MyDBContext cotext)
        {
            Context = cotext;
        }
        public  Task<HeaderRespone> Handle(GetHeaderPanelQuery request, CancellationToken cancellationToken)
        {
            var user =  Context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (user == null) return null;
            HeaderRespone _header = new HeaderRespone
            {
                Username = user.Username,
                Ip = user.Ip,
                LastVisting = user.LastLogin.ToString("dd/MM/yyyy HH:mm:ss"),
                In_B = user.BalanceIn.ToString("F2"),
                Out_B = user.BalanceOut.ToString("F2"),
                Total = (user.BalanceIn - user.BalanceOut).ToString("F2")
            };

            return Task.FromResult( _header);
        }
    }
}
