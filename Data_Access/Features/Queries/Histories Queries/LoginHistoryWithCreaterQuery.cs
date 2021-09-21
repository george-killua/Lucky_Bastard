using Data_Access.DBContext;
using Data_Access.Models;
using Data_Access.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access.Queries
{
    public class LoginHistoryWithCreaterQuery : IRequestWrapper<LoginHistory>
    {
        public LoginHistoryWithCreaterQuery(string userName)
        {
            UserName = userName;
        }

        internal string UserName { get; set; }

    }
    public class LoginHistoryWithCreaterQueryHandler : IRequestHandlerWrapper<LoginHistoryWithCreaterQuery, LoginHistory>
    {
        public MyDBContext Context { get; set; }
        public LoginHistoryWithCreaterQueryHandler(MyDBContext context)
        {
            Context = context;
        }





        public async Task<IEnumerable<LoginHistory>> Handle(LoginHistoryWithCreaterQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<LoginHistory> d = await Context.LoginHistories.Where(x => x.Creater == request.UserName).OrderByDescending(s => s.LoginDate).ToListAsync();
            return d;
        }
    }
}
