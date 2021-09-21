using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access.Features.Response
{
    public class UserInformationResponse
    {
        [Editable(false)]
        public string Username { get; set; }
        [Editable(false)]
        public int LoginTimes { get; set; } = 0;
        [Editable(false)]
        public decimal Balance { get; set; }
        [Editable(false)]
        public decimal B_in { get; set; } = 0;
        [Editable(false)]
        public decimal B_out { get; set; } = 0;
        [Editable(false)]
        public decimal B_Total { get; set; } = 0;
        [Editable(false)]
        public string Ip { get; set; } = "l";

    }
}
