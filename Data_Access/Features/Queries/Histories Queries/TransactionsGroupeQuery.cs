using Data_Access.DBContext;
using Data_Access.Response;
using Data_Access.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access.Queries
{
    public class TransactionsGroupeQuery : IRequestWrapper<TransactionsGroupRespone>
    {
        public TransactionsGroupeQuery(string userName)
        {
            UserName = userName;
        }

        internal string UserName { get; set; }
    }
    public class TransactionsGroupeQueryHandler : IRequestHandlerWrapper<TransactionsGroupeQuery, TransactionsGroupRespone>
    {
        public TransactionsGroupeQueryHandler(MyDBContext context)
        {
            Context = context;
        }

        public MyDBContext Context { get; set; }
        public async Task<IEnumerable<TransactionsGroupRespone>> Handle(TransactionsGroupeQuery request, CancellationToken cancellationToken)
        {
           IEnumerable<TransactionsGroupRespone> transactionsGroups = await Context.ChargeHistories.Where(x => x.Creater == request.UserName).GroupBy(x => new { x.Username })
              .Select(x => new TransactionsGroupRespone
              {
                  Username = x.Key.Username,
                  B_In = x.Sum(c => c.BalanceIn),
                  B_Out = x.Sum(c => c.BalanceOut),
                  B_Total = x.Sum(c => c.BalanceIn) - x.Sum(c => c.BalanceOut)
              }).OrderByDescending(s => s.Username).ToListAsync();
            return transactionsGroups;
        }
    }
}
