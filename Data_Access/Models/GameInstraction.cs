using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    [Table("GameInstractions")]
    public class GameInstraction
    {
        [Key]
        public int Id { get; set; }
        public string GameURL { get; set; }      
        public byte[] GameImageURL { get; set; }
        [MaxLength(32)]
        public string GameName { get; set; } 
    }
}
