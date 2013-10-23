using System;

namespace SecondZoo
{
    // Abstrakt basklass för alla kattdjur (Cat, Lion och Tiger). Klassen ärver
    // allt från Animal.
    public abstract class Feline : Animal
    {
        // Överskuggar basklassens version av Roam med en egen.
        public override void Roam()
        {
            Console.WriteLine("Strövar företrädesvis omkring på egen hand.");
        }
    }
}
