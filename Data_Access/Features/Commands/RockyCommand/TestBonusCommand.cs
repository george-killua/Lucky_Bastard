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
    public class TestBonusCommand : IRequest<Response<ValueSpinRespone>>
    {
    public RockySpinRequest RockySpinRequest { get; set; }

  
        public string Username { get;  set; }
    }
    public class TestBonusCommandHandler : IRequestHandler<TestBonusCommand, Response<ValueSpinRespone>>
    {
        private readonly IHttpContextAccessor _accessor;
        public MyDBContext Context { get; set; }
        public List<SymbolsDetails> Rockysymbols { get; }
        public SymbolsDetails RockysymbolsOne { get; private set; }


        public TestBonusCommandHandler(IHttpContextAccessor accessor, MyDBContext Contextt)
        {
            _accessor = accessor;
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


        public async Task<Response<ValueSpinRespone>> Handle(TestBonusCommand request, CancellationToken cancellationToken)
        {
            int Linesused = request.RockySpinRequest.Linesused;
             Random random = new Random();
            ValueSpinRespone returnedValue = new ValueSpinRespone();
            RockysymbolsOne = new SymbolsDetails();
            User user =  Context.Users.FirstOrDefault(x => x.Username == request.Username);
            decimal Amount = request.RockySpinRequest.RAmount;
            user.Balance -= Amount;
            Context.Users.Update(user);
            var secd = await Context.SaveChangesAsync();
            if (secd == 0)
            {
               
                
                return new Response<ValueSpinRespone>(false, ("error Happend while saving user balance")); ;

            }
            int[] symbol = new int[15] { 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1 };
            decimal tempbalance = user.Balance;
            int tempPOL = user.PercantageOfLuck;   
            returnedValue.WinningRows = new List<int[]>();
            //result of generated array
            for (int i = 1; i < Linesused; i++)
            {
                int[] tempresult = GameSetting.Result(i);
            
                if (symbol[tempresult[0]] == symbol[tempresult[1]] && symbol[tempresult[1]] == symbol[tempresult[2]] &&
                    symbol[tempresult[0]] == symbol[tempresult[4]] && symbol[tempresult[0]] == symbol[tempresult[3]])
                {
                    //check the winnig symbols 
                    RockysymbolsOne = Rockysymbols.FirstOrDefault(x => x.NameArrayNum == symbol[tempresult[0]]);
                    if (RockysymbolsOne.Wild == true)
                    {
                        returnedValue.IsWild = true;
                        returnedValue.SplitReelsCount = 5;
                        returnedValue.FreeSpinWildCount += 12;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));


                    }
                    else if (RockysymbolsOne.Bonus == true)
                    {
                        returnedValue.IsBonus = true;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));
                        returnedValue.FreeCrackingRock += (int)RockysymbolsOne.FiveOCcard;
                    }
                    else
                    {
                        returnedValue.WinValue += (RockysymbolsOne.FiveOCcard * Amount);
                        user.Balance += (RockysymbolsOne.FourOfCard * Amount);
                        returnedValue.WinningRows.Add(GameSetting.Result(i));

                        Context.Users.Update(user);
                        var sec = await Context.SaveChangesAsync();
                        if (sec == 0) return new Response<ValueSpinRespone>(false, ("error Happend while saving user balance"));
                    }
                }
                else if (symbol[tempresult[0]] == symbol[tempresult[1]] && symbol[tempresult[1]] == symbol[tempresult[2]] &&
            symbol[tempresult[0]] == symbol[tempresult[3]])
                {
                    //check the winnig symbols 
                    RockysymbolsOne = Rockysymbols.FirstOrDefault(x => x.NameArrayNum == symbol[tempresult[0]]);
                    if (RockysymbolsOne.Wild == true)
                    {
                        returnedValue.IsWild = true;
                        returnedValue.SplitReelsCount = 4;
                        returnedValue.FreeSpinWildCount += 6;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));


                    }
                    else if (RockysymbolsOne.Bonus == true)
                    {
                        returnedValue.IsBonus = true;
                        returnedValue.FreeCrackingRock += (int)RockysymbolsOne.FourOfCard;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));

                    }
                    else
                    {
                        returnedValue.WinValue += (RockysymbolsOne.FourOfCard * Amount);
                        user.Balance += (RockysymbolsOne.FourOfCard * Amount);
                       Context.Users.Update(user);
                        var sec = await Context.SaveChangesAsync();
                        if (sec == 0) return new Response<ValueSpinRespone>(false, ("error Happend while saving user balance"));
                        returnedValue.WinningRows.Add(GameSetting.Result(i));

                    }
                }

                else if (symbol[tempresult[0]] == symbol[tempresult[1]] && symbol[tempresult[1]] == symbol[tempresult[2]])
                {
                    //check the winnig symbols 
                    RockysymbolsOne = Rockysymbols.FirstOrDefault(x => x.NameArrayNum == symbol[tempresult[0]]);
                    if (RockysymbolsOne.Wild == true)
                    {
                        returnedValue.IsWild = true;
                        returnedValue.SplitReelsCount = 3;
                        returnedValue.FreeSpinWildCount += 2;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));


                    }
                    else if (RockysymbolsOne.Bonus == true)
                    {
                        returnedValue.IsBonus = true;
                        returnedValue.FreeCrackingRock += (int)RockysymbolsOne.ThreeOfCard;
                        returnedValue.WinningRows.Add(GameSetting.Result(i));

                    }
                    else
                    {
                        returnedValue.WinValue += (RockysymbolsOne.ThreeOfCard * Amount);
                        user.Balance += (RockysymbolsOne.ThreeOfCard * Amount);
                        Context.Users.Update(user);
                        returnedValue.WinningRows.Add(GameSetting.Result(i));

                        var sec = await Context.SaveChangesAsync();
                        if (sec == 0) return new Response<ValueSpinRespone>(false, ("error Happend while saving user balance"));
                    }
                }
            }
            if (Amount >= 1) GameSetting.Jackbotsave(Amount, user,Context);
            await GameSetting.SaveGamehistory(Amount, Linesused, user, tempbalance,_accessor,Context);
            returnedValue.ArrayOfSympbols = symbol;
            var ressave = await Context.SaveChangesAsync();
            if (ressave == 1) return new Response<ValueSpinRespone>(true, ("Success"),returnedValue);
            else return new Response<ValueSpinRespone>(false, ("Error Happend")); ;
        }
    }
}
