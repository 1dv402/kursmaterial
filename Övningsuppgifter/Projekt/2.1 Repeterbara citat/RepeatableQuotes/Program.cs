using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatableQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapar ett nytt QuotationViewer-objekt med hjälp
            // av standardkonstruktorn, använder egenskaper för 
            // att tilldela objektet värden och anropar en metod.
            QuotationViewer qw = new QuotationViewer();
            qw.Quotation = "I have a dream.";
            qw.Count = 7;
            qw.View();

            // Skapar och initierar ännu ett QuotationViewer-objekt 
            // med hjälp av konstruktorn som har två parametrar och 
            // anropar en metod.
            QuotationViewer anotherQw =
                new QuotationViewer("Make love, not war.", 3);
            anotherQw.View();

            // Ändrar på objektets data med hjälp av en egenskap 
            // och anropar en metod.
            anotherQw.Quotation = "Et tu, Brute";
            anotherQw.View();
        }
    }
}
