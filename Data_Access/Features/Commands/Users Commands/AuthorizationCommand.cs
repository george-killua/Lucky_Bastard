using Data_Access.DBContext;
using Data_Access.Features.Requestes;
using Data_Access.Features.Response;
using Data_Access.Helpers;
using Data_Access.Models;
using Data_Access.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access.Commands
{
    public class AuthorizationCommand : IRequest<AuthenticateResponse>
    {
        public AuthenticateRequest authenticateRequest = new AuthenticateRequest();
    }
    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand, AuthenticateResponse>
    {
        private readonly AppSettings _appSettings;

        private readonly MyDBContext _dbContext;
        private readonly IHttpContextAccessor _accessor;
        public AuthorizationCommandHandler(IOptions<AppSettings> appSettings, MyDBContext dbContext, IHttpContextAccessor accessor)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
            _accessor = accessor;
        }

        public async Task<AuthenticateResponse> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = _dbContext.Users.Where(x => x.Username == request.authenticateRequest.Username).FirstOrDefault();
            }

            catch (Exception ex)

            {
                return await Task.FromResult(new AuthenticateResponse(null, type: Enum.UserType.Player, ex.Message));
            }

            if (user == null)
                return null; 
            if (EncDec.Decrypt(user.Password)!=request.authenticateRequest.Password)
                return null;
            LoginHistory loginHistory = new LoginHistory()
            {
                Username = user.Username,
                Creater = user.Creater,
                Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)),
                Type = user.UserType.ToString()
                

            };
            if (user.UserType== Enum.UserType.Seller || user.UserType == Enum.UserType.Player)
            {
                var createrUser = _dbContext.Users.Where(x => x.Username == user.Creater).FirstOrDefault();
            
                if (createrUser != null) user.PercantageOfLuck = createrUser.PercantageOfLuck;
                var df = await _dbContext.LoginHistories.AddAsync(loginHistory);
                
            }
            user.Status = "On";
            user.LoginTimes++;
            user.LastLogin= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            user.Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var f =  _dbContext.Users.Update(user);
         var res=   await _dbContext.SaveChangesAsync();

            if (res == 0) return null;
            var type = user.UserType;
            var token = GenerateJwtToken(user);

            return await Task.FromResult(new AuthenticateResponse(user, type, token));
        }
        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
