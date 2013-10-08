using System;

namespace FirstZoo
{
    // Basklass för all hunddjur (Dog och Wolf). Klassen ärver
    // allt från Animal.
    //public class Canine : Animal
    public abstract class Canine : Animal
    {
        // Överskuggar basklassens version av Roam med en egen.
        public override void Roam()
        {
            Console.WriteLine("Strövar företrädesvis omkring i flock.");
        }
    }
}
