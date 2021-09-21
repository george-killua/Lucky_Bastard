using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    [Table("LoginHistories")]
    public class LoginHistory
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(32)]
        public string Username { get; set; }
        public DateTime  LoginDate { get; set; }
        public string Creater { get; set; }
        [MaxLength(16)]
        public string Type { get; set; }
        [MaxLength(32)]
        public string Ip { get; set; }   
        public virtual User User { get; set; }

    }
}
