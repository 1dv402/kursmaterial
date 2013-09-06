using System;

namespace GreetingLoopWithFor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabel.   
            int numberOfGreetings;

            // Användaren anger hur många gånger en hälsning ska göra.
            Console.Write("Hur många hälsningar vill du ge Monica? ");
            numberOfGreetings = int.Parse(Console.ReadLine());

            // Hälsningarna skrivs ut tills det inte finns några fler
            // att skriva ut.
            for (int i = 0; i < numberOfGreetings; i++)
            {
                Console.WriteLine("Hej Monica, hej på dig Monica!");
            }

            // Ett avslutande meddelande till användaren skrivs ut.
            Console.WriteLine("Slut på hälsningar...");
        }
    }
}
