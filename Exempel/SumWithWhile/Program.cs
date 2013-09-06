using System;

namespace SumWithWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler.
            int sum = 0;
            int number;

            // Läser in och summerar inmatade heltal. 0 avbryter.
            Console.Write("Ange heltalen som ska summeras: ");
            number = int.Parse(Console.ReadLine());
            while (number != 0)
            {
                sum += number;
                number = int.Parse(Console.ReadLine());
            }

            // Presenterar summan av de imatade talen.
            Console.WriteLine("Summan av talen är {0}.", sum);
        }
    }
}
