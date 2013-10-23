using System;
using System.Media;

namespace SecondZoo
{
    // Ärver direkt från klassen Animal.
    class Hippo : Animal
    {
        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\Hippo.wav");

            Console.Write("En flodhäst...");
            sp.PlaySync();
            Console.WriteLine("...plumsar?");
        }

        // Överskuggar basklassens version av Roam med en egen.
        public override void Roam()
        {
            Console.WriteLine("En flodhäst plumsar företrädesvis omkring...");
        }
    }
}
