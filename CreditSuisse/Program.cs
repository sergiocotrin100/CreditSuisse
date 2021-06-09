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

        static long GetNumberTrades()
        {
            long NumberTrades = 0;
            do
            {
                Console.WriteLine("Entre com o identificador da negociacao:");
                var Value = Console.ReadLine();
                NumberTrades = Value.ToLong();
                if (NumberTrades <= 0)
                {
                    Console.WriteLine("Identificador invalido");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            return NumberTrades;
        }

        static string GetCnab()
        {
            string Cnab = string.Empty;
            do
            {
                Console.WriteLine("Entre com o CNAB:");
                Cnab = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Cnab) || Cnab.Length==0)
                {
                    Console.WriteLine("CNAB invalido");
                    continue;
                }
                else if (Cnab.Split(' ').Length != 3)
                {
                    Console.WriteLine("CNAB está no formato inválido");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            return Cnab;
        }

        static void Start()
        {
            // Environment.Exit(1);
            Console.WriteLine("******************INICIO****************");
            var model = new TradeDTO();
            model.ReferenceDate = GetDate();
            model.NumberTrades = GetNumberTrades();
            model.CNAB = GetCnab();

            var business = new Business.TradeBusiness(model);
            Console.WriteLine($"A categoria é: {business.GetCategory()}");
            Console.WriteLine("******************FIM********************");
            Console.WriteLine();
            Start();
        }
    }
}
