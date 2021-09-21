using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Data_Access.Models;
using Data_Access.Helpers;
using Data_Access.DBContext;
using Data_Access.Response;
using System.Threading.Tasks;
using System.Threading;

namespace Data_Access.Queries
{
    public class LobbyHeaderJackpotsDetailsQuery : IRequest<LobbyHeaderJackpotsRespone>
    {
        public LobbyHeaderJackpotsDetailsQuery(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
    public class LobbyHeaderJackpotsDetailsQueryHandler : IRequestHandler<LobbyHeaderJackpotsDetailsQuery, LobbyHeaderJackpotsRespone>
    {
        public LobbyHeaderJackpotsDetailsQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public Task<LobbyHeaderJackpotsRespone> Handle(LobbyHeaderJackpotsDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = Context.Users.Where(x => x.Username == request.Username).FirstOrDefault();
            var Mini = Context.Minis.Where(x => x.Creater == user.Creater).FirstOrDefault().CurrentAmount;
            var Minor = Context.Minors.Where(x => x.Creater == user.Creater).FirstOrDefault().CurrentAmount;
            var Major = Context.Majors.Where(x => x.Creater == user.Creater).FirstOrDefault().CurrentAmount;
            var Grand = Context.Grands.FirstOrDefault().CurrentAmount;
            return Task.FromResult(new LobbyHeaderJackpotsRespone()
            {
                Mini = Mini.ToString(),
                Minor = Minor.ToString(),
                Major = Major.ToString(),
                Grand = Grand.ToString()
            });
        }
    }
}
