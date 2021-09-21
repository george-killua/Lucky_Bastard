using Data_Access.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Data_Access.Models
{
    [Table("users")]
    public class User
    {

        [Required]
        [MaxLength(32)]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public UserType UserType { get; set; }
        [Required]
        [MaxLength(32)]
        public string Creater { get; set; }
        public int LoginTimes { get; set; } = 0;
        public DateTime LastLogin { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceIn { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceOut { get; set; } = 0;
        [MaxLength(50)]
        public string Ip { get; set; } = "l";
        [MaxLength(3)]
        public string Status { get; set; } = "off";
        public int PercantageOfLuck { get; set; } = 70;
        [MaxLength(8)]
        public string DoubleBunosActive { get; set; } = "Active";
        [Column(TypeName = "decimal(18,2)")]
        public decimal Level { get; set; } = 0;
        [NotMapped]
        public ICollection<ChargeHistory> ChargeHistories { get; set; }
        [NotMapped]
        public ICollection<LoginHistory> LoginHistories { get; set; }
        [NotMapped]
        public ICollection<GameHistory> GameHistories { get; set; }
    }
}
