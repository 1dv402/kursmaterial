using System;

namespace CountVowelsInSayings
{
    // Borta bra men hemma bäst.
    // Tomma tunnor skramlar mest.
    // Mycket väsen för lite ull, sa käringen som klippte grisen.

    class Program
    {
        /// <summary>
        /// Startpunkt för applikationen.
        /// </summary>
        static void Main()
        {
            const int NumberOfSayingsToRead = 3;

            string[] sayings;
            int[] vowelCount;

            sayings = ReadSayings(NumberOfSayingsToRead);
            vowelCount = CountVowels(sayings);

            ViewVowelStatistics(sayings, vowelCount);
        }

        /// <summary>
        /// Räknar antalet vokaler i array med ordstäv.
        /// </summary>
        /// <param name="sayings">Array med ordstäv.</param>
        /// <returns>Array med antal vokaler ordstäven har.</returns>
        static int[] CountVowels(string[] sayings)
        {
            int[] result = new int[sayings.Length];

            for (int i = 0; i < sayings.Length; i++)
            {
                foreach (char ch in sayings[i])
                {
                    switch (Char.ToLower(ch))
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'y':
                        case 'å':
                        case 'ä':
                        case 'ö':
                            result[i]++;
                            break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Läser in angivet antal ordstäv.
        /// </summary>
        /// <param name="count">Antal ordstäv som ska läsas in.</param>
        /// <returns>Array med ordstäv.</returns>
        static string[] ReadSayings(int count)
        {
            string[] input = new string[count];

            Console.WriteLine("Ange {0} ordstäv.", count);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("Ordstäv nr.{0}: ", i + 1);
                input[i] = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Presenterar antalet vokaler ordstäv har.
        /// </summary>
        /// <param name="sayings">Array med ordstäv.</param>
        /// <param name="vowelCount">Array med antal vokaler ordstäv har.</param>
        static void ViewVowelStatistics(string[] sayings, int[] vowelCount)
        {
            Console.Clear();
            for (int i = 0; i < sayings.Length; i++)
            {
                Console.WriteLine("\n.:: Ordstäv #{0} ::.", i + 1);
                Console.WriteLine("------------------", i + 1);
                Console.WriteLine("Ordstävet");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("'{0}'", sayings[i]);
                Console.ResetColor();
                Console.WriteLine("innehåller {0} vokal{1}.\n",
                    vowelCount[i],
                    vowelCount[i] == 1 ? String.Empty : "er");
            }
        }

    }
}
