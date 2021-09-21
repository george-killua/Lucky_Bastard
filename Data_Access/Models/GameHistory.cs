using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    [Table("GameHistories")]
    public class GameHistory
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(32)]
        public string Username { get; set; }
        [MaxLength(32)]
        public string Creater { get; set; }
        [MaxLength(32)]
        public string GameName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Bet  { get; set; }
        //Win Lose Amount
        [Column(TypeName = "decimal(18,2)")]
        public decimal WLAmount  { get; set; }
        public int Lines  { get; set; }
        public string Ip { get; set; }
        public bool FreeSpin { get; set; } = false;
        public bool Wild { get; set; } = false;
        public DateTime Date { get; set; } =Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss",
                                  CultureInfo.InvariantCulture));

        public virtual User User { get; set; }



    }
}
