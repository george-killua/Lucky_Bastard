using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data_Access.Helpers;
using Data_Access.DBContext;
using Data_Access.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace Data_Access.Features
{

    public class SignalRHub : Hub<ISendRealtime>
    {    
        private Dictionary<string,string> Usernames { get; set; }
        private MyDBContext DBContext { get; set; }
        private HttpContext ContextHttp { get; set; }

        public SignalRHub(HttpContext context, MyDBContext dBContext)
        {
            this.ContextHttp = context;
            DBContext = dBContext;
        }

        public override Task OnConnectedAsync()
        {
            Usernames.Add(Context.ConnectionId,GUsername.GetUsername(ContextHttp));

            return base.OnConnectedAsync();
        }
        //public async Task<LobbyHeaderUserRespone> UserRespone()
        //{
        //    var user = DBContext.Users.Where(x => x.Username == GUsername.GetUsername(ContextHttp)).FirstOrDefault();

        //    var d = new LobbyHeaderUserRespone()
        //    {

        //        Balance = user.Balance.ToString(),
        //        Level = LevelUp(user.Level).ToString()
        //    };
        //    return await Clients.User(Usernames.FirstOrDefault(x => x.Value == user.Username).Key);

        //}
        //decimal LevelUp(decimal XP)
        //{
        //    decimal LevelBase = 5000;
        //    decimal level = 0;
        //    decimal nextLevel = LevelBase;

        //    decimal XPLeft = XP;

        //    while (XPLeft >= nextLevel)
        //    {
        //        level++;
        //        XPLeft -= nextLevel;

        //        nextLevel += (int)Math.Ceiling((float)nextLevel / 10);


        //    }

        //    return level;
        //}
        public async Task<LobbyHeaderJackpotsRespone> JackpotsRespone(string username)
        {
            return await Clients.User(Usernames.FirstOrDefault(x => x.Value == username).Key).SendJackpotDetails();

        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var TempUser = DBContext.Users.Where(x => x.Username == GUsername.GetUsername(ContextHttp)).FirstOrDefault();
            TempUser.Status = "Off";
            DBContext.Users.Update(TempUser);
            DBContext.SaveChanges();
            return base.OnDisconnectedAsync(exception);
        }

 


    }
    public interface ISendRealtime
    {
        Task<LobbyHeaderUserRespone> SendUserDetails();
        Task<LobbyHeaderJackpotsRespone> SendJackpotDetails();


    }
}
