using Data_Access.DBContext;
using Data_Access.Features.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Data_Access.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserInformationResponse>>{}

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserInformationResponse>>
    {
        
 
       
        public MyDBContext DBContext { get; }

        public GetAllUsersQueryHandler(MyDBContext dBContext)
        {
            DBContext = dBContext;
        }

    
        public async Task<IEnumerable<UserInformationResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // some buisness logic
          
            var UsersList =  await DBContext.Users.Select(x => new UserInformationResponse
            {
                Username = x.Username,
                LoginTimes = x.LoginTimes,
                Balance = x.Balance,
                B_in = x.BalanceIn,
                B_out = x.BalanceOut,
                B_Total = x.BalanceIn - x.BalanceOut,
                Ip = x.Ip



            }).OrderByDescending(x => x.Username).OrderByDescending(s=>s.Username).ToListAsync();
            if (UsersList == null)
            {
                return null;
            }
            return UsersList.AsReadOnly();
        }
    }
}
