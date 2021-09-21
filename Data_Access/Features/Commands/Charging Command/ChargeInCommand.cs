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
    public class ChargeInCommand : IRequest<string>
    {
        public BalanceInOutRequeste inOutRequeste = new BalanceInOutRequeste();
        public string Username { get; set; }
    }
    public class ChargeInCommandHandler : IRequestHandler<ChargeInCommand, string>
    {
        private readonly IHttpContextAccessor _accessor;
        public MyDBContext Context { get; set; }
        public ChargeInCommandHandler(MyDBContext context, IHttpContextAccessor accessor)
        {
            Context = context;
            _accessor = accessor;
        }



        public async Task<string> Handle(ChargeInCommand request, CancellationToken cancellationToken)
        {
            var curuse = Context.Users.FirstOrDefault(x => x.Username == request.Username);
            var recevieruse = Context.Users.FirstOrDefault(x => x.Username == request.inOutRequeste.EffectedUsername);
            if (recevieruse == null) return "Error";
            var d = TimeCheckRespone.CheckHouer(recevieruse.Username, Context);


            if (request.inOutRequeste.AmountIn <= curuse.Balance)
            {
                if (d.MoreThenHour == false || curuse.DoubleBunosActive == "Deactivate"||curuse.UserType!=Enum.UserType.Seller)
                {
                    curuse.Balance -= request.inOutRequeste.AmountIn;
                    curuse.BalanceOut += request.inOutRequeste.AmountIn;
                    Context.Users.Update(curuse);
                    recevieruse.Balance += request.inOutRequeste.AmountIn;
                    recevieruse.BalanceIn += request.inOutRequeste.AmountIn;
                    Context.Users.Update(recevieruse);


                    ChargeHistory re = new ChargeHistory()
                    {
                        Username = recevieruse.Username,
                        Creater = curuse.Username,
                        Bonus = 0,
                        BalanceIn = request.inOutRequeste.AmountIn,
                        BalanceOut = 0,
                        ChargeTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)),
                        Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                    };
                    Context.ChargeHistories.Add(re);
                    var res = await Context.SaveChangesAsync();
                    string tempmeassage = "balance in Successfully without bonus";
                    if (res > 0) return tempmeassage;
                    else
                        return "Error Hapend";
                }
                else
                {
                    curuse.Balance -= request.inOutRequeste.AmountIn;
                    curuse.BalanceOut += request.inOutRequeste.AmountIn;

                    Context.Users.Update(curuse);
                    recevieruse.Balance += request.inOutRequeste.AmountIn + request.inOutRequeste.AmountIn;
                    recevieruse.BalanceIn += request.inOutRequeste.AmountIn;
                    Context.Users.Update(recevieruse);


                    ChargeHistory re = new ChargeHistory()
                    {
                        Username = recevieruse.Username,
                        Creater = curuse.Username,
                        Bonus = request.inOutRequeste.AmountIn,
                        BalanceIn = request.inOutRequeste.AmountIn,
                        BalanceOut = 0,
                        ChargeTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)),
                        Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                    };
                    Context.ChargeHistories.Add(re);

                    string tempmeassage = "balance in Successfully with bonus";
                    var res = await Context.SaveChangesAsync();
                    if (res > 0) return tempmeassage;
                    else
                        return "Error Hapend";
                }

            }
            else
                return "you do not have enough credits";
        }
    }
}
