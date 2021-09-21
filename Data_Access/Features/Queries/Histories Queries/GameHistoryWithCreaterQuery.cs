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
    public class GameHistoryWithCreaterQuery : IRequestWrapper<ChargeHistory>
    {
        public GameHistoryWithCreaterQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
    public class GameHistoryWithCreaterQueryHandler : IRequestHandlerWrapper<GameHistoryWithCreaterQuery,ChargeHistory>
    {
        public GameHistoryWithCreaterQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public async Task<IEnumerable<ChargeHistory>> Handle(GameHistoryWithCreaterQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ChargeHistory> d = await Context.ChargeHistories.Where(x => x.Creater == request.UserName).OrderByDescending(s => s.ChargeTime).ToListAsync();
            return d;
        }
    }
}
