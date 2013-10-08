using System;
using System.Media;

namespace FirstZoo
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

        // Metoden kan bara anropas med hjälp av en referens av typen Dog;
        // går alltså inte med en referens av basklasstyp som t.ex. Animal.
        public void PeeOnLamppost()
        {
            Console.WriteLine("Peeeeeeeeeeee");
        }
    }
}
