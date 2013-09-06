using System;

namespace IntroducingMethods
{
    /// <summary>
    /// Exempel från Essential C# 5.0, kapitel 4, sidan 163-164.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Lokala variabler för förnamn, efternamn och fullständigt namn.
            string firstName;
            string lastName;
            string fullName;

            // Hämta indata från användaren.
            Console.WriteLine("Hallå där!");
            firstName = GetUserInput("Skriv in ditt förnamn: ");
            lastName = GetUserInput("Skriv in ditt efternamn: ");

            // Bestäm fullständigt namn och presentera det.
            fullName = GetFullName(firstName, lastName);
            DisplayGreeting(fullName);
        }

        static string GetUserInput(string prompt)
        {
            // Lokal variabel för hantering av data användaren matar in.
            string input;

            // Läs in och returnera datat användaren matar in.
            Console.Write(prompt);
            input = Console.ReadLine();

            return input;
        }

        static string GetFullName(string fName, string lName)
        {
            // Lokal variabel för hantering av det fullständiga namnet.
            string result;

            // Formaterar för- och efternamn till ett fullständigt namn och
            // returnera det.
            result = String.Format("{0} {1}", fName, lName);

            return result;
        }

        static void DisplayGreeting(string name)
        {
            // Skriv ut det fullständiga namnet och lämna metoden.
            Console.WriteLine("Ditt fullständiga namn är {0}.", name);
            return; // Behövs egentligen inte då metodens returtyp är void,
            // men är alltså fullt möjligt att använda även här.
        }
    }
}
