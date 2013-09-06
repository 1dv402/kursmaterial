using System;

namespace WhatAsciiRefactored
{
    class Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Deklarerar variabler.
                string line;
                int index;

                // Visar information om hur programmet ska användas.
                ViewIntroduction();

                // Läser in en rad med text.
                line = ReadTextRow();

                // Så länge som ett "giltigt" index anges ska tecknets ASCII-värde presenteras
                // och ett nytt index ska läsas in.
                index = ReadCharacterIndex();
                while (index >= 0)
                {
                    ViewCharInfo(line, index);
                    index = ReadCharacterIndex();
                }
            }

            // Visar hjälptext som introducerar applikationen.
            private static void ViewIntroduction()
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("* Test av strängar och teckens ASCII-värden *");
                Console.WriteLine("*-------------------------------------------*");
                Console.WriteLine("*                                           *");
                Console.WriteLine("* Programmet efterfrågar en rad med tecken. *");
                Console.WriteLine("* Därefter ska du ange ett index för ett    *");
                Console.WriteLine("* tecken i raden. Programmet avslutas om en *");
                Console.WriteLine("* negativt index anges.                     *");
                Console.WriteLine("*********************************************");
            }

            // Läser in ett teckens index.
            private static int ReadCharacterIndex()
            {
                Console.Write("Ange ett index (negativt avslutar): ");
                return int.Parse(Console.ReadLine());
            }

            // Läser in en textrad.
            private static string ReadTextRow()
            {
                Console.Write("Ange en rad med tecken: ");
                return Console.ReadLine();
            }

            // Presenterar specifierat teckens ASCII-värde.
            private static void ViewCharInfo(string text, int charIndex)
            {
                Console.WriteLine("\nTecknet på index {0} är ett '{1}' och har ASCII-värdet {2}",
                    charIndex, text[charIndex], (int)text[charIndex]);
            }
        }
    }
}
