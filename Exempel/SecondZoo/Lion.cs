using System;
using System.Media;

namespace SecondZoo
{
    // Ärver allt från klassen Feline.
    public class Lion : Feline
    {
        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\LionRoar.wav");

            Console.Write("Ett lejon...");
            sp.PlaySync();
            Console.WriteLine("...ryter");
        }
    }
}
