using System;
using System.Collections.Generic;
using System.Linq;
using Data_Access.Helpers;
using MediatR;
using Data_Access.Response;
using System.Threading.Tasks;
using System.Threading;
using Data_Access.DBContext;
using Microsoft.AspNetCore.Http;
using Data_Access.Models;
using Data_Access.Communication;
using Data_Access.Features.Requestes;

namespace Data_Access.Commands
{
    public class CrackRockCommand:IRequest<int?>
    {

        public string Username { get;  set; }
    }
    public class CrackRockCommandHandler : IRequestHandler<CrackRockCommand, int?>
    {
  
        public MyDBContext Context { get; set; }
        public List<SymbolsDetails> Rockysymbols { get; }
        public SymbolsDetails RockysymbolsOne { get; private set; }


        public CrackRockCommandHandler( MyDBContext Contextt)
        {
            
            Context = Contextt;
            Rockysymbols = new List<SymbolsDetails>() {
            new SymbolsDetails(){NameArrayNum=0,ThreeOfCard=0.06m,FourOfCard=0.10m,FiveOCcard=0.15m},
            new SymbolsDetails(){NameArrayNum=1,ThreeOfCard=0.12m,FourOfCard=0.2m,FiveOCcard=0.3m},
            new SymbolsDetails(){NameArrayNum=2,ThreeOfCard=0.24m,FourOfCard=0.30m,FiveOCcard=0.5m},
            new SymbolsDetails(){NameArrayNum=3,ThreeOfCard=3.6m,FourOfCard=5.2m,FiveOCcard=6.8m},
            new SymbolsDetails(){NameArrayNum=4,ThreeOfCard=4.5m,FourOfCard=7m,FiveOCcard=8.5m},
            new SymbolsDetails(){NameArrayNum=5,ThreeOfCard=5.4m,FourOfCard=8m,FiveOCcard=10m},
            new SymbolsDetails(){NameArrayNum=6,ThreeOfCard=3m,FourOfCard=4m,FiveOCcard=5m,Bonus=true},
            new SymbolsDetails(){NameArrayNum=7,ThreeOfCard=5m,FourOfCard=8m,FiveOCcard=15m,Wild=true}
            };
      
        }


        public async Task<int?> Handle(CrackRockCommand request, CancellationToken cancellationToken)
        {
            Random random = new Random();

            int res = random.Next(1, 15);
            User user = Context.Users.FirstOrDefault(x => x.Username == request.Username);
            user.Balance += res;
            user.Level += res;
            Context.Users.Update(user);
            var secd = await Context.SaveChangesAsync();
            if (secd > 0) return res;
            else return null;
        }
    }
}
