using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    [Table("ChargeHistories")]
    public class ChargeHistory
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(32)]
        public string Username { get; set; }
        [MaxLength(32)]
        public string Creater { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceIn { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal Bonus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceOut { get; set; }
        [NotMapped]
        public decimal BalanceTotal
        {
            get
            {
                return BalanceIn - BalanceOut;
            }
        }
        public DateTime ChargeTime { get; set; }
        [MaxLength(50)]
        public string Ip { get; set; }

        public virtual User User { get; set; }

    }
}
