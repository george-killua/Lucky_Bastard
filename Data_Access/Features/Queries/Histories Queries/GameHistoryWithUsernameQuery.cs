using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Data_Access.DBContext;
using System.Linq;
using Data_Access.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Data_Access.Wrappers;

namespace Data_Access.Queries
{
    public class GameHistoryWithUsernameQuery : IRequestWrapper<ChargeHistory>
    {
        public GameHistoryWithUsernameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
    public class GameHistoryWithUsernameQueryHandler : IRequestHandlerWrapper<GameHistoryWithUsernameQuery, ChargeHistory>
    {
        public GameHistoryWithUsernameQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public async Task<IEnumerable<ChargeHistory>> Handle(GameHistoryWithUsernameQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ChargeHistory> d = await Context.ChargeHistories.Where(x => x.Username == request.UserName).OrderByDescending(s => s.ChargeTime).ToListAsync();
            return d;
        }
    }
}
