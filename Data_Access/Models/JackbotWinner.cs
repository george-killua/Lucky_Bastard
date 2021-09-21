using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access
{
    [Table("jackbotWinner")]
    public class JackbotWinner
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(32)]
        public string JackbotName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount{ get; set; }
        public DateTime DateOfWinning { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss",CultureInfo.InvariantCulture));
        [MaxLength(32)]
        public string WinnerName { get; set; }
        public bool GotIt { get; set; } = false;



    }
}
