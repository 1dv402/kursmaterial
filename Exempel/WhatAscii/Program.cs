using System;

namespace WhatAscii
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler.
            string line;
            int index;

            // Visar hjälptext som introducerar applikationen.
            Console.WriteLine("*********************************************");
            Console.WriteLine("* Test av strängar och teckens ASCII-värden *");
            Console.WriteLine("*-------------------------------------------*");
            Console.WriteLine("*                                           *");
            Console.WriteLine("* Programmet efterfrågar en rad med tecken. *");
            Console.WriteLine("* Därefter ska du ange ett index för ett    *");
            Console.WriteLine("* tecken i raden. Programmet avslutas om en *");
            Console.WriteLine("* negativt index anges.                     *");
            Console.WriteLine("*********************************************");

            // Läser in en textrad.
            Console.Write("Ange en rad med tecken: ");
            line = Console.ReadLine();

            // Läser in ett teckens index.
            Console.Write("Ange ett index (negativt avslutar): ");
            index = int.Parse(Console.ReadLine());

            // Så länge som ett "giltigt" index anges ska tecknets ASCII-värde presenteras
            // och ett nytt index ska läsas in.
            while (index >= 0)
            {
                Console.WriteLine("\nTecknet på index {0} är ett '{1}' och har ASCII-värdet {2}",
                    index, line[index], (int)line[index]);

                Console.Write("Ange ett index (negativt avslutar): ");
                index = int.Parse(Console.ReadLine());
            }
        }
    }
}
