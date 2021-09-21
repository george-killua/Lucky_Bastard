using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access.Response
{
    public class OutModelRespone
    {
        [Editable(false)]
        public decimal Balance { get; set; }
        [Editable(false)]
        public string Message { get; set; }
    }
}
