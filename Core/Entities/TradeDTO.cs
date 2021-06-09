using System;

namespace Core.Entities
{
    public class TradeDTO
    {
        public long NumberTrades { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string CNAB { get; set; }
    }
}
