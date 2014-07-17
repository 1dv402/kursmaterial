using System;

namespace _1DV402.S2.L1C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Strings.Title;

            // Testa grundläggande krav på klassen SecretNumber.
            Test.Run();

            // Deklarera och initiera lokala variabler. 
            bool continueGame = false;
            int number = 0;
            string message = null;
            SecretNumber secretNumber = new SecretNumber();

            // Upprepa spelomgångar tills användaren avslutar genom att 
            // trycka ner tangenten 'N'.
            do
            {
                // Initiera ny spelomgång.
                secretNumber.Initialize();

                // Låt användaren gissa så länge det finns gissningar kvar. 
                while (secretNumber.CanMakeGuess)
                {
                    // Rensa konsolfönstret och skriv ut eventuellt gjorda gissningar
                    // och meddelande.
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔══════════════════════════════════════╗ ");
                    Console.WriteLine(" ║ Gissa det hemliga talet mellan 1-100 ║ ");
                    Console.WriteLine(" ╚══════════════════════════════════════╝ \n");
                    Console.ResetColor();
                    if (secretNumber.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        GuessedNumber[] results = secretNumber.GuessedNumbers;
                        for (int i = 0; i < secretNumber.Count; i++)
                        {
                            Console.BackgroundColor = results[i].Outcome == Outcome.High ?
                                ConsoleColor.Red : ConsoleColor.Blue;
                            Console.Write(" {0} ", results[i].Number);
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n");
                    }

                    if (!String.IsNullOrWhiteSpace(message))
                    {
                        Console.WriteLine(message);
                        Console.WriteLine();
                    }

                    // Läs in en gissning i det slutna intervallet mellan 1 och 100.
                    Console.ForegroundColor = ConsoleColor.White;
                    var prompt = String.Format(Strings.Guess_Number,
                        Strings.ResourceManager.GetString(String.Format("Count_{0}", secretNumber.Count + 1)));
                    do
                    {
                        Console.Write(prompt);
                    } while (!(int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= 100));
                    Console.ResetColor();

                    try
                    {
                        // Gissa och skapa meddelande beroende på utfallet av gissningen.
                        if (secretNumber.MakeGuess(number) != Outcome.Right)
                        {
                            message = String.Format(Strings.ResourceManager.GetString(String.Format("Outcome_{0}",
                                secretNumber.Outcome.ToString())), secretNumber.Guess);
                        }
                        else
                        {
                            message = String.Format(Strings.Outcome_Right,
                                Strings.ResourceManager.GetString(String.Format("Count_{0}", secretNumber.Count)).ToLower());
                        }

                        // Avsluta omgången om det inte går att gissa fler gånger och om senaste gissningen inte var rätt.
                        if (!secretNumber.CanMakeGuess && secretNumber.Outcome != Outcome.Right)
                        {
                            message += String.Format(Strings.Cannot_Guess, secretNumber.Number);
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
                Console.WriteLine();
                Console.WriteLine(message);

                Console.BackgroundColor = ConsoleColor.DarkRed;
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