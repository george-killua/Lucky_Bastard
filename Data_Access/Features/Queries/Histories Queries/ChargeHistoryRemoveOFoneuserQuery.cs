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
    public class ChargeHistoryRemoveOFoneuserQuery : IRequest<string>
    {
        public ChargeHistoryRemoveOFoneuserQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
    public class ChargeHistoryRemoveOFoneuserQueryHandler : IRequestHandler<ChargeHistoryRemoveOFoneuserQuery, string>
    {
        public ChargeHistoryRemoveOFoneuserQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public async Task<string> Handle(ChargeHistoryRemoveOFoneuserQuery request, CancellationToken cancellationToken)
        {
            var templ = await Context.ChargeHistories.Where(x => x.Username == request.UserName).ToListAsync();
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
