using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Helpers
{
    public class SymbolsDetails
    {
        public int NameArrayNum { get; set; }
        public decimal ThreeOfCard { get; set; }
        public decimal FourOfCard { get; set; }
        public decimal FiveOCcard { get; set; }
        public bool Bonus { get; set; } = false;
        public bool Wild { get; set; } = false;
    }
}
