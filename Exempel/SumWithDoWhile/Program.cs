using System;

namespace SumWithDoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler.
            int sum = 0;
            int number = 0;

            // Läser in och summerar inmatade heltal. 0 avbryter.
            Console.Write("Ange heltalen som ska summeras: ");
            do
            {
                sum += number;
                number = int.Parse(Console.ReadLine());
            } while (number != 0);

            // Presenterar summan av de imatade talen.
            Console.WriteLine("Summan av talen är {0}.", sum);
        }
    }
}
