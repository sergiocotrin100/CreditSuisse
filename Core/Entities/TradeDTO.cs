using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class TradeDTO
    {
        public int NumberTrades { get; set; }
        public DateTime ReferenceDate { get; set; }
        public List<string> Trades { get; set; }
    }
}
