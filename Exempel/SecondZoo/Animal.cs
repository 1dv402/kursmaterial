using System;

namespace SecondZoo
{
    // Abstrakt basklass, det går inte att instansiera objekt av klassen, för alla djur. 
    // Klassen ärver faktiskt från Object även om det inte uttryckligen står att den 
    // gör det ( : Object saknas efter Animal).
    public abstract class Animal : INoise
    {
        // Publik egenskap som det inte finns någon anledning till att överskugga
        // varför egenskapen inte är virtuell.
        public uint Age { get; set; }

        // Abstract metod som klasser som ärver från Animal måste
        // implementera för att skapa sin egen version av.
        public abstract void MakeNoise();

        // Abstract metod som klasser som ärver från Animal måste
        // implementera för att skapa sin egen version av.
        public abstract void Roam();

        // Virtuell metod som klasser som ärver från Animal kan välja
        // att överskugga (override) för att skapa sin egen version av.
        public virtual void Sleep()
        {
            Console.WriteLine("Zzzzzzzz");
        }
    }
}
