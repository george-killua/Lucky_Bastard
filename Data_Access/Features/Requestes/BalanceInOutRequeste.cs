using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access.Requestes
{
    public class BalanceInOutRequeste
    {
        [Required]
        [Display(Name = "receiver username")]
        public string EffectedUsername { get; set; }
        [Required]

        [Display(Name = "amount in")]
        public decimal AmountIn { get; set; }
    }
}
