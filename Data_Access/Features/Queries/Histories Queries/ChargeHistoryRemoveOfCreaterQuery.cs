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
    public class ChargeHistoryRemoveOfCreaterQuery : IRequest<string>
    {
        public ChargeHistoryRemoveOfCreaterQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
    public class ChargeHistoryRemoveOfCreaterQueryHandler : IRequestHandler<ChargeHistoryRemoveOfCreaterQuery, string>
    {
        public ChargeHistoryRemoveOfCreaterQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public async Task<string> Handle(ChargeHistoryRemoveOfCreaterQuery request, CancellationToken cancellationToken)
        {
            var templ = await Context.ChargeHistories.Where(x => x.Creater == request.UserName).ToListAsync();
            Context.ChargeHistories.RemoveRange(templ);
            var res = await Context.SaveChangesAsync();
            if (res > 0)
                return "Records Deleted";
            else
            {
                return "Error Happend";
            }
        }
    }
}
