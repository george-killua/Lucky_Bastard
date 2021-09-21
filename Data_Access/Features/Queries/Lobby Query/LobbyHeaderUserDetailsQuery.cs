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
    public class LobbyHeaderUserDetailsQuery:IRequest<LobbyHeaderUserRespone>
    {
        public LobbyHeaderUserDetailsQuery(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
    public class LobbyHeaderUserDetailsQueryHandler : IRequestHandler<LobbyHeaderUserDetailsQuery, LobbyHeaderUserRespone>
    {
        public LobbyHeaderUserDetailsQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public Task<LobbyHeaderUserRespone> Handle(LobbyHeaderUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user =  Context.Users.Where(x => x.Username == request.Username).FirstOrDefault();
            return Task.FromResult( new LobbyHeaderUserRespone()
            {
          
                Balance = user.Balance.ToString(),
                Level = LevelUp(user.Level).ToString()
            });
        }
        decimal LevelUp(decimal XP)
        {
            decimal LevelBase = 5000;
            decimal level = 0;
            decimal nextLevel = LevelBase;

            decimal XPLeft = XP;

            while (XPLeft >= nextLevel)
            {
                level++;
                XPLeft -= nextLevel;

                nextLevel += (int)Math.Ceiling((float)nextLevel / 10);


            }

            return level;
        }
    }
}
