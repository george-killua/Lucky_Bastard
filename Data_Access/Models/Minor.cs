using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data_Access.Models
{
    [Table("Mainer")]
    public class Minor
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Prize { get; set; }
        [MaxLength(32)]
        public string Creater { get; set; }
     
    }
}
