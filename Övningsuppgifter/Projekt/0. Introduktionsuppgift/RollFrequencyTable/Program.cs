using System;

namespace RollFrequencyTable
{
    /// <summary>
    /// Applikationen simulerar tärningskast och presenterar utfallet i 
    /// form av en frekvenstabell.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Startpunkt för applikationen.
        /// </summary>
        /// <param name="args">Argument som kan skickas till applikationen (används 
        /// inte).</param>
        static void Main(string[] args)
        {
            // Deklarerar lokala variabler.
            int count = 0;
            int[] frequencyTable = null;

            // Läser in hur många tärningskast som ska simuleras då
            // en frekvenstabell över tärningskast skapas och presenteras.
            count = ReadNumberOfRolls();

            frequencyTable = RollDie(count);

            ViewFrequencyTable(frequencyTable);
        }

        /// <summary>
        /// Efterfrågar, läser in och returnerar antalet tärningskast som ska simuleras.
        /// </summary>
        /// <returns>Antal tärningskast.</returns>
        private static int ReadNumberOfRolls()
        {
            // Deklarerar lokal variabel.
            int count = 0;

            // Läser in och returnerar ett heltal mellan 100 och 1000.
            while (true)
            {
                try
                {
                    Console.Write("Ange antal tärningskast [100-1000]: ");
                    count = int.Parse(Console.ReadLine());
                    if (count < 100 || count > 1000)
                    {
                        throw new ApplicationException();
                    }
                    return count;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! Ange ett heltal mellan 100 och 1000.\n");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Simulerar tärningskast, skapar och returnerar frekvenstabell över utfallet.
        /// </summary>
        /// <param name="count">Antal tärningskast att simulera.</param>
        /// <returns>Array innehållande frekvenstabell över simulerade 
        /// tärningskast.</returns>
        private static int[] RollDie(int count)
        {
            // Deklarerar lokala variabler.
            int[] frequencyTable = new int[6];
            Random die = new Random();

            // Slumpar tärningskast och uppdaterar frekvenstabellen som därefter 
            // returneras.
            for (int i = 0; i < count; i++)
            {
                frequencyTable[die.Next(0, 6)]++;
            }

            return frequencyTable;
        }

        /// <summary>
        /// Presenterar en frekvenstabell över tärningskast.
        /// </summary>
        /// <param name="frequencyTable">Referens till frekvenstabell i form av en array
        /// innehållade utfallet av tärningskast.</param>
        private static void ViewFrequencyTable(int[] frequencyTable)
        {
            // Deklarerar lokal variabel.
            string[] facets = { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor" };

            // Går igenom tärningssida för tärningssida och skriver ut tärningssidans 
            // namn samt antalet gånger sidan "kommit upp" vid ett tärningskast. 
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n----------------");
            Console.WriteLine(" Frekvenstabell ");
            Console.WriteLine("----------------");
            Console.ResetColor();
            for (int i = 0; i < facets.Length; i++)
            {
                Console.WriteLine(" {0,-7} | {1,4}", facets[i], frequencyTable[i]);
                Console.WriteLine("----------------");
            }
        }

    }
}