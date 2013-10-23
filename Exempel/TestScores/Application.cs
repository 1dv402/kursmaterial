using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestScores
{
    /// <summary>
    /// Representerar applikationen.
    /// </summary>
    class Application
    {
        /// <summary>
        /// Läser värden från textfil och presentera statistik över värdena.
        /// </summary>
        public void Run()
        {
            List<int> scores = Load();
            ViewDetails(scores);
        }

        /// <summary>
        /// Returnerar samling med värden som lästs från textfil med kommaseparerade 
        /// resultat, som tolkas och sorteras i fallande ordning.
        /// </summary>
        /// <returns>Sorterad samling med resultat.</returns>
        private List<int> Load()
        {
            // Samling för resultat av typen int.
            List<int> testScores = new List<int>();

            // Öppnar filen med resultat och...
            using (StreamReader reader = new StreamReader("TestScores.csv"))
            {
                string line;

                // ...läser den rad för rad.
                while ((line = reader.ReadLine()) != null)
                {
                    // Delar upp en sträng med 10 resultat till tio delsträngar 
                    // med ett resultat i varje sträng.
                    string[] scores = line.Split(new char[] { ',', ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    // Gör om varje sträng med resultat till ett resultat av typen int och lägger till
                    // heltalet till samlingen med heltalsresultat.
                    foreach (string score in scores)
                    {
                        testScores.Add(int.Parse(score));
                    }

                    //// Alternativ lösning #1 (med lamda uttryck och omedelbar frågeutvärdering).
                    //testScores.AddRange(
                    //    line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    //    .Select(s => int.Parse(s))
                    //    .ToList());

                    //// Alternativ lösning #2 (med LINQ).
                    //IEnumerable<int> scores = from score in line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    //                          select int.Parse(score);
                    //testScores.AddRange(scores);
                }
            }

            // Sortera listan med resultat.
            testScores.Sort();

            return testScores;
        }

        /// <summary>
        /// Presenterar statistiska uppgifter för samling med värden.
        /// </summary>
        /// <param name="scores">Samling med resultat.</param>
        private void ViewDetails(List<int> scores)
        {
            // Presentera största, minsta och medelvärde.
            Console.WriteLine("Max        : {0}", scores.Max());
            Console.WriteLine("Min        : {0}", scores.Min());
            Console.WriteLine("Medelvärde : {0:f1}", scores.Average());

            // Hur många jämna resultat?
            int evenCount = scores.Where(s => s % 2 == 0).Count();
            Console.WriteLine("Antal jämna: {0}", evenCount);
        }
    }
}
