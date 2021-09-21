using Data_Access.DBContext;
using Data_Access.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Helpers
{
   public class GUsername
    {
  

        public static string GetUsername(HttpContext  context) 
            {
                User user = (User)context.Items["User"];
            return user.Username;

            } 
    }
}
