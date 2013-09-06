using System;

namespace AverageExamScore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler.
            int totalScore;
            int numberOfParticipants;
            double averageScore;

            // Läser in värden från tangentbordet.
            Console.Write("Ange den totala poängsumman: ");
            totalScore = int.Parse(Console.ReadLine());

            Console.Write("Ange totalt antal deltagare: ");
            numberOfParticipants = int.Parse(Console.ReadLine());

            // Beräkningar deltagarnas medelpoäng.
            averageScore = (double)totalScore / numberOfParticipants;

            // Presenterar medelpoängen.
            Console.WriteLine("Deltagarnas medelpoäng är {0:f1}.",
                averageScore);
        }
    }
}
