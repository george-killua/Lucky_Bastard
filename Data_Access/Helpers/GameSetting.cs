using Data_Access.DBContext;
using Data_Access.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access.Helpers
{
   public class GameSetting
    {
        static readonly Random random = new Random();
        public static async Task SaveGamehistory(decimal Amount, int Linesused, User user, decimal tempbalance, IHttpContextAccessor _accessor, MyDBContext context) => await context.GameHistories.AddAsync(new GameHistory
        {
            Username = user.Username,
            Creater = user.Creater,
            Balance = user.Balance,
            GameName = "Rocky",
            Lines = Linesused,
            Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
            WLAmount = user.Balance - tempbalance,
            Bet = Amount

        });
        public static int ReturnedSymbols
        {
            get
            {
                var tempran = random.Next(0, 100);
                if (tempran < 25) return 0;
                else if (tempran < 40) return 1;
                else if (tempran < 51) return 2;
                else if (tempran < 62) return 3;
                else if (tempran < 73) return 4;
                else if (tempran < 90) return 5;
                else if (tempran < 95) return 6;
                else return 7;

            }
        }


        public static int ReturnedSymbolsFreeSpin
        {
            get
            {
                var tempran = random.Next(0, 100);
                if (tempran < 35) return 0;
                else if (tempran < 49) return 1;
                else if (tempran < 58) return 2;
                else if (tempran < 70) return 3;
                else if (tempran < 88) return 4;
                else return 5;
            }
        }

        public static int[] Result(int lineNumber)
        {

            return lineNumber switch
            {
                1 => new[] { 5, 6, 7, 8, 9 },
                3 => new[] { 10, 11, 12, 13, 14 },
                4 => new[] { 5, 1, 2, 3, 9 },
                5 => new[] { 5, 11, 12, 13, 9 },
                6 => new[] { 0, 1, 7, 3, 4 },
                7 => new[] { 10, 11, 7, 13, 14 },
                8 => new[] { 0, 6, 12, 8, 4 },
                9 => new[] { 10, 6, 2, 8, 14 },
                10 => new[] { 5, 11, 7, 3, 9 },
                11 => new[] { 5, 1, 7, 13, 9 },
                12 => new[] { 0, 6, 7, 8, 4 },
                13 => new[] { 10, 6, 7, 8, 14 },
                14 => new[] { 0, 6, 2, 8, 4 },
                15 => new[] { 10, 6, 12, 8, 14 },
                16 => new[] { 5, 6, 2, 8, 9 },
                17 => new[] { 5, 6, 12, 8, 9 },
                18 => new[] { 0, 1, 12, 3, 4 },
                19 => new[] { 10, 11, 2, 13, 14 },
                20 => new[] { 0, 11, 12, 13, 4 },
                _ => new[] { 0, 1, 2, 3, 4 },
            };
        }

        #region jackpot
        public static void Jackbotsave(decimal Amount, User user, MyDBContext context)
        {
            MiniJackbotSaveAsync(Amount, user,context);
            MinorJackbotSaveAsync(Amount, user,context);
            MajorJackbotSaveAsync(Amount, user, context);
            GrandJackbotSaveAsync(Amount, context);
        } 
        private static async void GrandJackbotSaveAsync(decimal Amount,  MyDBContext context)
        {
            var res = context.Grands.FirstOrDefault();
            decimal mvalue = Amount / 100;
            if (res != null)
            {

                res.CurrentAmount += mvalue;
                if (res.CurrentAmount >= res.Prize)
                {
                    List<User> tusers = context.Users.Where(x => x.Status == "online").ToList();
                    int splitPrize = (int)(res.Prize / tusers.Count);
                    foreach (var item in tusers)
                    {
                        await context.JackbotWinners.AddAsync(new JackbotWinner
                        {
                            Amount = splitPrize,
                            JackbotName = "grand Jackbot",
                            WinnerName = item.Username
                        });
                    }

                }
            }
            else
            {
                await context.Grands.AddAsync(new Grand
                {
        
                    CurrentAmount = 10000 + mvalue
                    ,
                    Prize = random.Next(40000, 50000)

                });
            }
            context.SaveChanges();

        }


        private async static void MajorJackbotSaveAsync(decimal Amount, User user, MyDBContext context)
        {
            var res = context.Majors.FirstOrDefault(x => x.Creater == user.Creater);
            decimal mvalue = Amount * 0.05m;
            if (res != null)
            {

                res.CurrentAmount += mvalue;
                if (res.CurrentAmount >= res.Prize)
                {
                    await context.JackbotWinners.AddAsync(new JackbotWinner
                    {
                        Amount = res.Prize,
                        JackbotName = "Major Jackbot",
                        WinnerName = user.Username
                    });
                }
            }
            else
            {
                await context.Majors.AddAsync(new Major
                {
                    Creater = user.Creater,
                    CurrentAmount = 100 + mvalue
                    ,
                    Prize = random.Next(400, 500)

                });
            }
            context.SaveChanges();

        }
        private async static void MiniJackbotSaveAsync(decimal Amount, User user, MyDBContext context)
        {
            var res = context.Minis.FirstOrDefault(x => x.Creater == user.Creater);
            decimal mvalue = Amount * 0.05m;
            if (res != null)
            {

                res.CurrentAmount += mvalue;
                if (res.CurrentAmount >= res.Prize)
                {
                    var rres = await context.JackbotWinners.AddAsync(new JackbotWinner
                    {
                        Amount = res.Prize,
                        JackbotName = "Mini Jackbot",
                        WinnerName = user.Username
                    });

                }
            }
            else
            {
                await context.Minis.AddAsync(new Mini
                {
                    Creater = user.Creater,
                    CurrentAmount = 20 + mvalue
                    ,
                    Prize = random.Next(400, 500)

                });
            }
            context.SaveChanges();
        }
        private async static void MinorJackbotSaveAsync(decimal Amount, User user, MyDBContext context)
        {
            var res = context.Minors.FirstOrDefault(x => x.Creater == user.Creater);
            decimal mvalue = Amount * 0.05m;
            if (res != null)
            {

                res.CurrentAmount += mvalue;
                if (res.CurrentAmount >= res.Prize)
                {
                    await context.JackbotWinners.AddAsync(new JackbotWinner
                    {
                        Amount = res.Prize,
                        JackbotName = "Minor Jackbot",
                        WinnerName = user.Username
                    });
                }
            }
            else
            {
                await context.Minors.AddAsync(new Minor
                {
                    Creater = user.Creater,
                    CurrentAmount = 75 + mvalue
                    ,
                    Prize = random.Next(160, 200)

                });
            }
            context.SaveChanges();

        }
        #endregion
    }
}
