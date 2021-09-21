using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data_Access.DBContext;
using Data_Access.Models;
using Data_Access.Response;
using MediatR;


namespace Data_Access.Queries
{
  public  class OpenBOutModelQuery : IRequest<OutModelRespone>
    {
        public string Username { get; set; }
    }
    public class OpenBOutModelQueryHandler : IRequestHandler<OpenBOutModelQuery, OutModelRespone>
    {
        public MyDBContext Context { get; set; }
        public OpenBOutModelQueryHandler(MyDBContext dBContext)
        {
            Context = dBContext;
        }

      

        public Task<OutModelRespone> Handle(OpenBOutModelQuery request, CancellationToken cancellationToken)
        {
            var user=Context.Users.FirstOrDefault(x => x.Username == request.Username);
                    if (user == null) return Task.FromResult( new OutModelRespone() { Message = "user not Found", Balance = 0 });
            ChargeHistory charge = Context.ChargeHistories.
                OrderByDescending(x => x.ChargeTime.Hour).
                ThenByDescending(f => f.ChargeTime.Minute).
                Where(c => c.Username == request.Username&& c.BalanceOut == 0).
                FirstOrDefault();
        
            decimal Bonus;
            if (charge == null)
                Bonus = 0;
            else
                Bonus = charge.Bonus;

            decimal tempBalance = user.Balance;
            OutModelRespone tempbool = new OutModelRespone();
            if ((Bonus * 5) <= tempBalance && Bonus != 0)
            {
                tempbool.Balance = tempBalance;
                tempbool.Message = "balance with bonus";
            }
            else if (tempBalance == 0 )
            {
                tempbool.Message = "Player do not have balance";

            }
            else
            {
                tempBalance -= Bonus;
                if ((tempBalance) > 0)
                {
                    tempbool.Balance = tempBalance;
                    tempbool.Message = "balance without bonus";
                }
                else if (tempBalance < 0)

                {
                    tempbool.Balance = tempBalance;
                    tempbool.Message = "Transaction Can noT be done because after taking out the bunos the balance will be negative : " + tempbool.Balance;
                }
                else
                {
                    tempbool.Message = "Player do not have balance";
                }
            }

            return Task.FromResult(tempbool);
        }
    }
}
