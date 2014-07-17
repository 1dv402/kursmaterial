using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DV402.S2.L1B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Gissa det hemliga talet - nivå B";

            // Testa grundläggande krav på klassen SecretNumber.
            Test.Run();

            // Deklarera och initiera lokala variabler. 
            bool continueGame = false;
            int number = 0;
            SecretNumber secretNumber = new SecretNumber();

            // Upprepa spelomgångar tills användaren avslutar genom att 
            // trycka ner tangenten 'N'.
            do
            {
                // Initiera ny spelomgång.
                secretNumber.Initialize();

                // Rensa konsolfönstret och skriv ut ledtext.
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════╗ ");
                Console.WriteLine(" ║ Gissa det hemliga talet mellan 1-100 ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════╝ ");
                Console.ResetColor();

                // Låt användaren gissa så länge det finns gissningar kvar. 
                while (secretNumber.CanMakeGuess)
                {
                    // Läs in en gissning i det slutna intervallet mellan 1 och 100.
                    Console.ForegroundColor = ConsoleColor.White;
                    do
                    {
                        Console.Write("\nGissning {0}: ", secretNumber.Count + 1);
                    } while (!(int.TryParse(Console.ReadLine(), out number) &&
                        number >= 1 && number <= 100));
                    Console.ResetColor();
                    Console.WriteLine();

                    try
                    {
                        // Gissa och avsluta spelomgången om gissningen är rätt.
                        if (secretNumber.MakeGuess(number))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ett oväntat fel inträffade! Programmet avbryts.");
                        Console.WriteLine(ex.Message);
                        return;
                    }

                }
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n    Nytt hemligt nummer? [N] avbryter.    ");
                Console.CursorVisible = false;
                continueGame = Console.ReadKey(true).Key != ConsoleKey.N;
                Console.CursorVisible = true;
                Console.ResetColor();
            } while (continueGame);
        }
    }
}
