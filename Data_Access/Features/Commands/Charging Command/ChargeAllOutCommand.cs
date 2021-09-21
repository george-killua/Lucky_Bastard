using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data_Access.DBContext;
using Data_Access.Models;
using Data_Access.Requestes;
using Data_Access.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Data_Access.Commands
{
    public class ChargeAllOutCommand : IRequest<string>
    {
        public BalanceInOutRequeste inOutRequeste = new BalanceInOutRequeste();
    }
    public class ChargeAllOutCommandHandler : IRequestHandler<ChargeAllOutCommand, string>
    {
        private readonly IHttpContextAccessor _accessor;
        public MyDBContext Context { get; set; }
        public ChargeAllOutCommandHandler(MyDBContext context, IHttpContextAccessor accessor)
        {
            Context = context;
            _accessor = accessor;
        }



        public async Task<string> Handle(ChargeAllOutCommand request, CancellationToken cancellationToken)
        {
            var recevieruse = Context.Users.FirstOrDefault(x => x.Username == request.inOutRequeste.EffectedUsername);
            if (recevieruse == null) return "Error";
            var currentB = recevieruse.Balance;
                recevieruse.Balance -= currentB;
                recevieruse.BalanceOut += currentB;
                Context.Users.Update(recevieruse);

                ChargeHistory re = new ChargeHistory()
                {
                    Username = recevieruse.Username,
                    Creater = recevieruse.Creater,
                    Bonus = 0,
                    BalanceIn = 0,
                    BalanceOut = currentB,
                    ChargeTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)),
                    Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                Context.ChargeHistories.Add(re);
                var res = await Context.SaveChangesAsync();
                string tempmeassage = "Balance All out Successfully";
                if (res > 0) return tempmeassage;
                else
                    return "Error Happend";
            }
    }
}
