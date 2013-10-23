using System;
using System.Media;

namespace SecondZoo
{
    // Ärver allt från klassen Canine.
    public class Wolf : Canine
    {
        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\Wolf.wav");

            Console.Write("En varg...");
            sp.PlaySync();
            Console.WriteLine("...ylar");
        }
    }
}
