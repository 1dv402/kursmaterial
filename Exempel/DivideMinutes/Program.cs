using System;

namespace DivideMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Namngivna konstanter.
            const int MinutesPerHour = 60;
            const int MinutesPerDay = MinutesPerHour * 24;

            // Deklaration och initiering av variabler.
            int minutes = 123456;
            int hours;
            int days;
            int remainingMinutes;

            // Uppdelning av minuter i dagar...
            remainingMinutes = minutes;
            days = remainingMinutes / MinutesPerDay;
            remainingMinutes = remainingMinutes % MinutesPerDay; // antal minuter som återstår då dagarna tagits bort

            // ...och timmar.
            hours = remainingMinutes / MinutesPerHour;
            remainingMinutes %= MinutesPerHour; //antal minuter som återstår då timmarna tagits bort.

            // Utskrift av resultat.
            Console.WriteLine("{0} minuter blir {1} dagar, {2} timmar och {3} minuter",
                minutes, days, hours, remainingMinutes);
        }
    }
}
