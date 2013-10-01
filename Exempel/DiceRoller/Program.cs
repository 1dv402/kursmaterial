using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapar två tärningsobjekt.
            Die die1 = new Die();
            Die die2 = new Die();

            // Kastar de två tärningarna och skriver ut 
            // resultatet av tärningskasten.
            for (int i = 0; i < 1000; ++i)
            {
                Console.WriteLine("1: {0}\t2: {1}",
                    die1.Roll(), die2.Roll());
            }

            // Skriver ut resultatet av det senaste
            // kastet med den första tärningen.
            Console.WriteLine(die1);
        }
    }
}
