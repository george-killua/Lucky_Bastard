using Data_Access.DBContext;
using Data_Access.Features.Response;
using Data_Access.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access.Queries
{
    public class GetAllUserWCreatersQuery : IRequest<IEnumerable<UserInformationResponse>>
    {
        public GetAllUserWCreatersQuery(string creater)
        {
            Creater = creater;
        }

        public string Creater { get; set; }
    }

    public class GetAllUserWCreatersQueryHandler : IRequestHandler<GetAllUserWCreatersQuery, IEnumerable<UserInformationResponse>>
    {
        private  MyDBContext Cotext { get; set; }

        public GetAllUserWCreatersQueryHandler(MyDBContext cotext)
        {
            this.Cotext = cotext;
        }

    

        public async Task<IEnumerable<UserInformationResponse>> Handle(GetAllUserWCreatersQuery request, CancellationToken cancellationToken)
        {
            // some buisness logic
          
            var UsersList = await Cotext.Users.Where(x=>x.Creater==request.Creater).Select(x => new UserInformationResponse
            {
                Username = x.Username,
                LoginTimes = x.LoginTimes,
                Balance = x.Balance,
                B_in = x.BalanceIn,
                B_out = x.BalanceOut,
                B_Total = x.BalanceIn - x.BalanceOut,
                Ip = x.Ip



            }).OrderByDescending(x => x.Username).ToListAsync();
            if (UsersList == null)
            {
                return null;
            }
            return UsersList.AsReadOnly();
        }
    }
}
