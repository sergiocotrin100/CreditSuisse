using Core.Entities;
using Core.Interfaces;
using CrossCutting;
using System;

namespace Business
{
    public class TradeBusiness : ITrade
    {
        readonly double HIGHRISKVALUE = 1000.000;
        readonly double MEDIUMRISKVALUE = 1000.000;
        readonly string EXPIRED = "EXPIRED";
        readonly string HIGHRISK = "HIGHRISK";
        readonly string MEDIUMRISK = "MEDIUMRISK";

        private TradeDTO Trade { get; set; }

        public TradeBusiness(TradeDTO trade)
        {
            this.Trade = trade;
        }
        public double Value
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                    if (!string.IsNullOrWhiteSpace(this.Trade.CNAB))
                        return this.Trade.CNAB.Split(' ')[0].ToDouble();

                return 0;
            }
        }

        public string ClientSector
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                    if (!string.IsNullOrWhiteSpace(this.Trade.CNAB))
                        return this.Trade.CNAB.Split(' ')[1];

                return string.Empty;
            }
        }

        public DateTime NextPaymentDate
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                    if (!string.IsNullOrWhiteSpace(this.Trade.CNAB))
                        return this.Trade.CNAB.Split(' ')[2].ToDateTime();

                return DateTime.MinValue;
            }
        }

        public bool IsPoliticallyExposed => this.IsPoliticallyExposed;

        private bool IsExpired
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                {
                    TimeSpan time = this.Trade.ReferenceDate - this.NextPaymentDate;
                    return time.Days > 30;
                }

                return false;
            }
        }

        private bool IsHighRisk
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                {
                    return (this.Value > this.HIGHRISKVALUE && this.IsClientPrivateSector);
                }

                return false;
            }
        }

        private bool IsMediumRisk
        {
            get
            {
                if (this.Trade != null && this.Trade.NumberTrades > 0)
                {
                    return (this.Value > this.MEDIUMRISKVALUE && this.IsClientPublicSector);
                }

                return false;
            }
        }

        private bool IsClientPrivateSector
        {
            get
            {
                return this.ClientSector.Equals("Private", StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool IsClientPublicSector
        {
            get
            {
                return this.ClientSector.Equals("Public", StringComparison.OrdinalIgnoreCase);
            }
        }

        public string GetCategory()
        {
            if (this.IsExpired)
                return this.EXPIRED;
            else if (this.IsMediumRisk)
                return this.MEDIUMRISK;
            else if (this.IsHighRisk)
                return this.HIGHRISK;
            else
                return string.Empty;
        }
    }
}
