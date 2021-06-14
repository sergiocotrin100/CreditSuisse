using Core.Entities;
using System;
using System.Text;

namespace Business
{
    public class TradeBusiness
    {
        readonly double HIGHRISKVALUE = 1000.000;
        readonly double MEDIUMRISKVALUE = 1000.000;
        readonly string EXPIRED = "EXPIRED";
        readonly string HIGHRISK = "HIGHRISK";
        readonly string MEDIUMRISK = "MEDIUMRISK";
        readonly int DaysLate = 30;

        private TradeDTO Trade { get; set; }        

        public TradeBusiness(TradeDTO trade)
        {
            this.Trade = trade;
        }

        private bool IsExpired(DateTime NextPaymentDate)
        {
            if (this.Trade != null && this.Trade.NumberTrades > 0)
            {
                TimeSpan time = this.Trade.ReferenceDate - NextPaymentDate;
                return time.Days > this.DaysLate;
            }

            return false;
        }

        private bool IsHighRisk(Trade model)
        {
            return (model.Value > this.HIGHRISKVALUE && this.IsClientPrivateSector(model.ClientSector));
        }

        private bool IsMediumRisk(Trade model)
        {
            return (model.Value > this.MEDIUMRISKVALUE && this.IsClientPublicSector(model.ClientSector));
        }

        private bool IsClientPrivateSector(string clientSector)
        {
            return clientSector.Equals("Private", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsClientPublicSector(string clientSector)
        {
            return clientSector.Equals("Public", StringComparison.OrdinalIgnoreCase);
        }

        public string GetCategory()
        {
            StringBuilder strResult = new StringBuilder();
            foreach (var trade in this.Trade.Trades)
            {
                Trade model = new Trade(trade);

                if (this.IsExpired(model.NextPaymentDate))
                    strResult.AppendLine(this.EXPIRED);
                else if (this.IsMediumRisk(model))
                    strResult.AppendLine(this.MEDIUMRISK);
                else if (this.IsHighRisk(model))
                    strResult.AppendLine(this.HIGHRISK);
            }

            return strResult.ToString();
        }
    }
}
