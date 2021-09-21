using Data_Access.DBContext;
using Data_Access.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Data_Access.Helpers
{
    public class JwTMiddleWare
    {

        private readonly RequestDelegate _next;
        private readonly IServiceProvider serviceProvider;
        private readonly AppSettings _appSettings;
        
        public JwTMiddleWare(RequestDelegate next, IOptions<AppSettings> appSettings,IServiceProvider serviceProvider )
        {
            _next = next;
            this.serviceProvider = serviceProvider;
            _appSettings = appSettings.Value;
         
    }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                string userId = jwtToken.Claims.First(x => x.Type == "username").Value;

                // attach user to context on successful jwt validation
#pragma warning disable IDE0063 // Use simple 'using' statement
                using (IServiceScope serviceScope = serviceProvider.CreateScope()){
#pragma warning restore IDE0063 // Use simple 'using' statement
                    var f = serviceScope.ServiceProvider.GetService<MyDBContext>();
                    try { context.Items["User"] = f.Users.FirstOrDefault(x => x.Username == userId); 
                   
                    }
                    catch (Exception)
                    {

                    }
                }
                // Seed the database.

            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}