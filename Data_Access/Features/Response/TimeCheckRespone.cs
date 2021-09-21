using Data_Access.DBContext;
using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Data_Access.Response
{
    public class TimeCheckRespone
    {
        [Editable(false)]
        public bool MoreThenHour { get; set; }
        [Editable(false)]
        public string TimeLeft { get; set; }
        public string ErrorMessage { get; set; }
        public static TimeCheckRespone CheckHouer(string username, MyDBContext _context)
        {
            TimeCheckRespone _timecheck = new TimeCheckRespone();
            ChargeHistory charge = _context.ChargeHistories.OrderByDescending(x => x.ChargeTime.Hour).
                ThenByDescending(f => f.ChargeTime.Minute).Where(c => c.Username == username && c.BalanceOut == 0)
                .FirstOrDefault();
            TimeSpan ts=new TimeSpan(15,1,0);
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (charge != null&& user.UserType != Enum.UserType.Player)
            {
                DateTime date1 = Convert.ToDateTime(charge.ChargeTime.ToString("dd/MM/yyyy HH:mm:ss",
                         CultureInfo.InvariantCulture));
                DateTime date2 = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss",
                                          CultureInfo.InvariantCulture));
               ts= date2 - date1;
            }
            if (ts.TotalHours < 1)
            {
                int temps = (int)(60 - ts.Minutes);
                _timecheck.TimeLeft = "bonus available in : " + temps + " Minutes";
                _timecheck.MoreThenHour = false;
            }
            else
            {
                _timecheck.TimeLeft = "bonus available";

                _timecheck.MoreThenHour = true;


            }

            return _timecheck;
        }
    }
}
