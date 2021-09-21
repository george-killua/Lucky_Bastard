using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Response
{
    public class ValueSpinRespone
    {
        public int[] ArrayOfSympbols { get; set; }
        public List<int[]> WinningRows { get; set; }
        public decimal WinValue { get; set; } = 0;
        public int FreeCrackingRock { get; set; } = 0;
        public int FreeSpinWildCount { get; set; } = 0;
        public bool IsBonus { get; set; } = false;
        public int SplitReelsCount { get; set; } = 0;
        public bool IsWild { get; set; } = false;

    }
}
