using System;
using System.Media;

namespace SecondZoo
{
    // Ärver allt från klassen Feline.
    public class Tiger : Feline
    {
        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\Tiger.wav");

            Console.Write("En tiger...");
            sp.PlaySync();
            Console.WriteLine("...ryter");
        }
    }
}
