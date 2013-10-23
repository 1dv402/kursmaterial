using System;
using System.Media;

namespace SecondZoo
{
    // Ärver från klassen Canine.
    public class Dog : Canine
    {
        // Utökar med en egen autoimplementerad egenskap.
        public string Name { get; set; }

        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\DogBark.wav");

            Console.Write("En hund...");
            sp.PlaySync();
            Console.WriteLine("...skäller");
        }
    }
}
