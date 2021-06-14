using Core.Interfaces;
using CrossCutting;
using System;

namespace Business
{
    public class Trade : ITrade
    {
        public Trade(string _trade)
        {
            this.TradeSelected = _trade;
        }
        private string TradeSelected { get; set; }
        public double Value
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.TradeSelected))
                    return this.TradeSelected.Split(' ')[0].ToDouble();

                return 0;
            }
        }

        public string ClientSector
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.TradeSelected))
                    return this.TradeSelected.Split(' ')[1];

                return string.Empty;
            }
        }

        public DateTime NextPaymentDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.TradeSelected))
                    return this.TradeSelected.Split(' ')[2].ToDateTime();
                return DateTime.MinValue;
            }
        }

        public bool IsPoliticallyExposed => false;

      
    }
}
