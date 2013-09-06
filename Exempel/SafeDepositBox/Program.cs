using System;

namespace SafeDepositBox
{
    class Program
    {
        // Konstant innehållande den rätta koden till kassaskåpet.
        const int GuestPassword = 9685;

        static void Main(string[] args)
        {
            // Deklaration av variabel för kod som användaren anger.
            int password;

            // Användaren anger koden...
            Console.Write("Ange koden till kassaskåpet: ");
            password = int.Parse(Console.ReadLine());

            // ...som kontrolleras och om...
            Console.ForegroundColor = ConsoleColor.White;
            if (GuestPassword == password)
            {
                // ...koden är rätt öppnas kassaskåpet...
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Rätt kod! Kassaskåpet är öppet.");
            }
            else
            {
                // ...annars öppnas inte kassaskåpet.
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Fel kod!");
            }
            Console.ResetColor();
        }
    }
}
