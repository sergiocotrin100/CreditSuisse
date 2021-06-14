using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;
using Core.Entities;

namespace CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo!!!");
            Start();
            Console.Read();
        }

        static DateTime GetDate()
        {
            DateTime ReferenceDate = DateTime.MinValue;
            do
            {
                Console.WriteLine("Entre com a data de referência:");
                var Value = Console.ReadLine();
                ReferenceDate = Value.ToDateTime();
                if (ReferenceDate == DateTime.MinValue)
                {
                    Console.WriteLine("Data invalida");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            return ReferenceDate;
        }

        static int GetNumberTrades()
        {
            int NumberTrades = 0;
            do
            {
                Console.WriteLine("Entre com o identificador da negociação:");
                var Value = Console.ReadLine();
                NumberTrades = Value.ToInt();
                if (NumberTrades <= 0)
                {
                    Console.WriteLine("Identificador inválido");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            return NumberTrades;
        }

        //static string GetTrade()
        //{
        //    string trade = string.Empty;
        //    do
        //    {
        //        Console.WriteLine("Entre com a lista de Trade:");
        //        trade = Console.ReadLine();
        //        if (string.IsNullOrWhiteSpace(trade) || trade.Length==0)
        //        {
        //            Console.WriteLine("Trade inválido");
        //            continue;
        //        }
        //        else if (trade.Split(' ').Length != 3)
        //        {
        //            Console.WriteLine("Trade está no formato inválido");
        //            continue;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    } while (true);

        //    return trade;
        //}

        static List<string> GetTrade(int numberTrades)
        {
            List<string> lstTrades = new List<string>();
            Console.WriteLine("Entre com a lista de Trade:");

            for (int i = 0; i < numberTrades; i++)
            {
                string trade = Console.ReadLine();
                if (!string.IsNullOrEmpty(trade))
                {
                    lstTrades.Add(trade);
                }

            }

            return lstTrades;
        }

        static void Start()
        {
            Console.WriteLine("******************INICIO****************");
            var model = new TradeDTO();
            model.ReferenceDate = GetDate();
            model.NumberTrades = GetNumberTrades();
            model.Trades = GetTrade(model.NumberTrades);

            var business = new Business.TradeBusiness(model);
            Console.WriteLine(business.GetCategory());

            Console.WriteLine("******************FIM********************");
            Console.WriteLine();
            Start();
        }
    }
}
