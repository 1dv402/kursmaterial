using System;
using System.Media;

namespace SecondZoo
{
    // Ärver allt från klassen Feline.
    public class Cat : Feline
    {
        // Utökar med en egen autoimplementerad egenskap.
        public string Name { get; set; }

        // Överskuggar basklassens version av MakeNoise med en egen.
        public override void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\CatMeow.wav");

            Console.Write("En katt säger...");
            sp.PlaySync();
            Console.WriteLine("...mjau");
        }
    }
}
