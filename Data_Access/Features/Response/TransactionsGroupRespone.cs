using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access.Response
{
    public class TransactionsGroupRespone
    {
        public TransactionsGroupRespone()
        {
        }
        [Editable(false)]
        public string Username { get; set; }
        [Editable(false)]
        public decimal B_In { get; set; }
        [Editable(false)]
        public decimal B_Out { get; set; }
        [Editable(false)]
        public decimal B_Total { get; set; }
    }
}
