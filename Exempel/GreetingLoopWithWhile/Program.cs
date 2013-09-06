using System;

namespace GreetingLoopWithWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar och initierar variabel.
            int numberOfGreetings;

            // Användaren anger hur många gånger en hälsning ska göra.
            Console.Write("Hur många hälsningar vill du ge Monica? ");
            numberOfGreetings = int.Parse(Console.ReadLine());

            // Hälsningarna skrivs ut tills det inte finns några fler
            // att skriva ut.
            while (numberOfGreetings > 0)
            {
                Console.WriteLine("Hej Monica, hej på dig Monica!");
                --numberOfGreetings;
            }

            // Ett avslutande meddelande till användaren skrivs ut.
            Console.WriteLine("Slut på hälsningar...");
        }
    }
}
